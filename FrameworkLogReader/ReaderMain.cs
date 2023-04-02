using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Bogus;
using Bogus.DataSets;
using ICSharpCode.TextEditor.Document;
using ICSharpCode.TextEditor;
using TextEditor;

namespace FrameworkLogReader
{

    public partial class ReaderMain : Form
    {


        
        
        private string initDir = "";
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
                Console.WriteLine("Dialog cancelled");
                return false;
            }
            
        }

        private void workingDirectoyMenu_Click(object sender, EventArgs e)
        {
            if (!GetWorkingDirectory())
            {
                
            }

        }

        private void FileMenu_Click(object sender, EventArgs e)
        {
            
        }

        private void statusBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
        }

        private void itemTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //MessageBox.Show("Path is: " + e.Node.FullPath);
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
                        //MessageBox.Show("Path is: " + pth);

                        var res = FileHelper.ReadFile(pth);
                        if (res.Item1 == true)
                        {
                            displayBox.Text = res.Item2;
                        }
                        else
                        {
                            MessageBox.Show(
                                "Failed to open file: " + Environment.NewLine + Environment.NewLine +
                                res.Item2.ToString(), "Bollox", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            //e.
            
        }

        private void ReaderMain_Load(object sender, EventArgs e)
        {
            InitialDirectory = FrameworkLogReader.Properties.Settings.Default.WorkingDir;
            
            displayBox.Highlighting = "Java";
            
            //throw new System.NotImplementedException();
            
            int offset = 5;
            int length = 5;
            TextMarker marker = new TextMarker(offset, length, TextMarkerType.WaveLine, Color.Red);
            displayBox.Document.MarkerStrategy.AddMarker(marker);
            //displayBox.EnableRedo();
            //displayBox.EnableRedo = true;
            setupDisplayBox();
            HightLightKeywords();

        }

        private void setupDisplayBox()
        {
            try
            {
                
                TextMarker errorMarker = new TextMarker(5, 5, TextMarkerType.SolidBlock, Color.Crimson);

                //displayBox.Document.TextEditorProperties.

               //HighlightRuleSet r = new HighlightRuleSet();
                //r.
                    
                displayBox.Highlighting = "ERROR";
                displayBox.EnableFolding = true;
                displayBox.ShowEOLMarkers = true;
                displayBox.ShowSpaces = true;
                displayBox.ShowTabs = true;
                displayBox.ShowHRuler = true;
                displayBox.ShowVRuler = true;
                displayBox.ShowMatchingBracket = true;

            }
            catch (Exception e)
            {
                MessageBox.Show(
                    "An error occureed while attempting to format display:" + Environment.NewLine +
                    Environment.NewLine + e.Message, "Setup Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //throw;
            }
        }

        private void  HightLightKeywords()
        {
            bool _lastSearchLoopedAround;
            TextEditorSearcher _search = new TextEditorSearcher();
            //TODO: find all keywords
            //create: highlight groups
            //colour highlight groups
            TextEditorControl Editor = displayBox;
            string texttosearchfor = "ERROR";
            _search.ClearScanRegion();
            _search.LookFor=texttosearchfor;
            _search.MatchWholeWordOnly = true;
            int startFrom = 0;
            
            TextRange range = _search.FindNext(startFrom, false, out _lastSearchLoopedAround);
            //var sm = displayBox.ActiveTextAreaControl.SelectionManager;
            MessageBox.Show("COCK");
            
            
            
        }


    }
    
    
}