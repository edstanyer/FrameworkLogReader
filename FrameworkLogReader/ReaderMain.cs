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
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name,1,2));
            return directoryNode;
        }
        #endregion file listing 
        
        public ReaderMain()
        {
            InitializeComponent();
        }


        private void openButton_Click(object sender, EventArgs e)
        {
            /*FolderBrowserDialog fd = new FolderBrowserDialog();

            fd.RootFolder = Environment.SpecialFolder.Desktop;

            DialogResult res= fd.ShowDialog();
            if (res == DialogResult.OK)
            {
               Console.WriteLine( "Folder Selected: " + fd.SelectedPath);
               List<string> fs = new List<string>();
               RecursiveDirectoryListing r = new RecursiveDirectoryListing();

               r.GetFiles(ref fs, fd.SelectedPath, true);

            }
            else
            {
                Console.WriteLine("Dialog cancelled");
            }*/
        }
        private bool GetWorkingDirectory()
        {
            
            FolderBrowserDialog fd = new FolderBrowserDialog();

            fd.RootFolder = Environment.SpecialFolder.Desktop;

            DialogResult res= fd.ShowDialog();
            if (res == DialogResult.OK)
            {
                InitialDirectory = fd.SelectedPath;
                StatusLabel.Text = "Working Directory: " + InitialDirectory.Replace(Path.GetDirectoryName(fd.SelectedPath), "");
                StatusLabel.ForeColor = Color.Black;
                StatusLabel.BackColor = Color.Transparent;
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
                        MessageBox.Show("Path is: " + pth);

                        var res = FileHelper.ReadFile(pth);
                        if (res.Item1 == true)
                        {
                            displayBox.Text = res.Item2;
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
            
        }

        private void itemTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //e.
            
        }
    }
}