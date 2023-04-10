using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.CompilerServices;
using Bogus;
using Bogus.DataSets;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using TextEditor;

namespace FrameworkLogReader
{

    public partial class ReaderMain : Form
    {
        private HighlightGroup Errors;
        private HighlightGroup Warnings;
        private HighlightGroup Info;

        private string initDir = "";

        /// <summary>
        /// Property for working directory - basically the base parent directory from which the software
        /// finds its child directories & files. 
        /// </summary>
        public string InitialDirectory
        {
            get
            {
                return initDir;
            }

            set
            {
                string dir = value;
                if(Directory.Exists(dir))
                {
                    initDir = dir;
                    ListDirectory(itemTree, initDir);
                    FrameworkLogReader.Properties.Settings.Default.WorkingDir = initDir;
                    FrameworkLogReader.Properties.Settings.Default.Save();
                    StatusLabel.Text = "Working Directory: " + InitialDirectory;//.Replace(Path.GetDirectoryName(fd.SelectedPath), "");
                    StatusLabel.ForeColor = Color.Black;
                    StatusLabel.BackColor = Color.Transparent;
                }

            }
        }



        //todo look at extending tree view class!
        #region file listing
        private void ListDirectory(TreeView treeView, string path)
        {
            
            treeView.Nodes.Clear();
            var rootDirectoryInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectoryInfo));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name, 0,0);
            foreach (var directory in directoryInfo.GetDirectories())
            {
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
                
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                string ext = Path.GetExtension((file.ToString()));

                if (!ext.Contains("."))
                {
                }

                directoryNode.Nodes.Add(new TreeNode(file.Name,1,2));
                
            }
            return directoryNode;
        }
        #endregion file listing 
        
        public ReaderMain()
        {
            InitializeComponent();
        }


        private void openButton_Click(object sender, EventArgs e)
        {
           
        }
        /// <summary>
        /// Browse for the working parent directory
        /// </summary>
        /// <returns></returns>
        private bool GetWorkingDirectory()
        {
            
            FolderBrowserDialog fd = new FolderBrowserDialog();

            fd.RootFolder = Environment.SpecialFolder.Desktop;

            DialogResult res= fd.ShowDialog();
            if (res == DialogResult.OK)
            {
                InitialDirectory = fd.SelectedPath;
                return true;
            }
            else
            {
                MessageBox.Show("User cancelled directory selection", "Working Directory", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return false;
            }
            
        }

        private void workingDirectoyMenu_Click(object sender, EventArgs e)
        {
            GetWorkingDirectory(); //this returns a bool, but quite what you'd do it is anyone's guess
        }

        private void FileMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void statusBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void itemTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null && e.Node.Text != "")
            {
                TreeNode node = e.Node;
                if (node.GetNodeCount(true) == 0)
                {
                    //must be a file as it has no children - that it knows of....phnarr 
                    string pth = node.FullPath;
                    if (! string.IsNullOrWhiteSpace(initDir) == true  && Directory.Exists((initDir)))
                    {
                        pth  = Directory.GetParent(initDir).ToString() +  (char) 92 + pth ;
                        OpenFile(pth);
                    }

                   
                }
            }
            //throw new System.NotImplementedException();
        }

        private void itemTree_Click(object sender, EventArgs e)
        {
            
            // throw new System.NotImplementedException();
        }

        private void itemTree_MouseClick(object sender, MouseEventArgs e)
        {
            //make some changes
        }

        private void itemTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
        }

        private void ReaderMain_Load(object sender, EventArgs e)
        {
            InitialDirectory = FrameworkLogReader.Properties.Settings.Default.WorkingDir;   
        }

        
        private void OpenFile(string fileName)
        {
            displayBox.Clear(); //not sure what this does, apart from the bleeding obvious!
            
            #region sanity check file
            if (!fileName.ValidFile())
            {
                MessageBox.Show("The file " + fileName + " is not valid. Please check your data for possible reasons",
                    "File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            #endregion

            #region read and display the file
            try
            {
                var res = FileHelper.ReadFile(fileName);
                if (res.Item1 == false)
                {
                    MessageBox.Show(
                        "Failed to open file: " + Environment.NewLine + Environment.NewLine +
                        res.Item2.ToString(), "File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    displayBox.Text = res.Item2;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "Failed to open file: " + Environment.NewLine + Environment.NewLine +
                    e.Message, "File Read Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            #endregion read and display the file

            #region set basic highlight
           
            /*Errors = new HighlightGroup(displayBox);
            Warnings = new HighlightGroup(displayBox);
            Info = new HighlightGroup(displayBox);*/
            
             FindAll("ERROR", Color.Crimson, Color.Azure);
             FindAll("WARN", Color.Yellow, Color.Black);
             FindAll("INFO", Color.Chartreuse, Color.Black);
            
            #endregion set basic highlight

        }

        private HighlightGroup FindAll(string phrase, Color blockColour, Color textColour)
        {
            HighlightGroup hg = new HighlightGroup(displayBox);
            if (string.IsNullOrEmpty( phrase))
            {
                return hg;
            }

            bool looped = false;
            int offset = 0, count = 0;
            TextEditorSearcher searcher = new TextEditorSearcher();
            searcher.Document = displayBox.Document;
            searcher.MatchCase = true;
            searcher.LookFor = phrase;
            for (;;)
            {
                TextRange range = searcher.FindNext(offset, false, out looped);

                if (range == null || looped)
                {
                    break;
                }

                offset = range.Offset + range.Length;
                count++;
                var m = new TextMarker(range.Offset, range.Length, 
                    TextMarkerType.SolidBlock, blockColour, textColour);
                
                hg.AddMarker(m);
                HighlightGroup.UseCompatibleTextRendering = true;
                Application.DoEvents();
            }

            return hg;


        }


        private void errorCheck_CheckedChanged(object sender, EventArgs e)
        {

            
            

        }

        private void itemTree_MouseUp(object sender, MouseEventArgs e)
        {
            //throw new System.NotImplementedException();
        }
    }
    
    
}