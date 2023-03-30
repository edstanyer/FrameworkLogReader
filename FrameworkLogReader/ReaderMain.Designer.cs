﻿namespace FrameworkLogReader
{
    partial class ReaderMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReaderMain));
            this.openButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.topToolBar = new System.Windows.Forms.ToolStrip();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.workingDirectoyMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.EditMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.mainSplitter = new System.Windows.Forms.SplitContainer();
            this.itemTree = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.displayBox = new System.Windows.Forms.RichTextBox();
            this.mainMenu.SuspendLayout();
            this.statusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).BeginInit();
            this.mainSplitter.Panel1.SuspendLayout();
            this.mainSplitter.Panel2.SuspendLayout();
            this.mainSplitter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openButton
            // 
            this.openButton.AutoSize = true;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.Location = new System.Drawing.Point(1437, 494);
            this.openButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(105, 68);
            this.openButton.TabIndex = 0;
            this.openButton.Text = "Select Folder";
            this.openButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1040, 383);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(8, 7);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // topToolBar
            // 
            this.topToolBar.Location = new System.Drawing.Point(0, 28);
            this.topToolBar.Name = "topToolBar";
            this.topToolBar.Size = new System.Drawing.Size(1792, 25);
            this.topToolBar.TabIndex = 6;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.FileMenu, this.EditMenu, this.ViewMenu, this.SettingsMenu });
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.mainMenu.Size = new System.Drawing.Size(1792, 28);
            this.mainMenu.TabIndex = 7;
            this.mainMenu.Text = "menuStrip1";
            // 
            // FileMenu
            // 
            this.FileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { this.workingDirectoyMenu });
            this.FileMenu.Name = "FileMenu";
            this.FileMenu.Size = new System.Drawing.Size(44, 24);
            this.FileMenu.Text = "&File";
            this.FileMenu.Click += new System.EventHandler(this.FileMenu_Click);
            // 
            // workingDirectoyMenu
            // 
            this.workingDirectoyMenu.Name = "workingDirectoyMenu";
            this.workingDirectoyMenu.Size = new System.Drawing.Size(193, 24);
            this.workingDirectoyMenu.Text = "Working &Directoy";
            this.workingDirectoyMenu.Click += new System.EventHandler(this.workingDirectoyMenu_Click);
            // 
            // EditMenu
            // 
            this.EditMenu.Name = "EditMenu";
            this.EditMenu.Size = new System.Drawing.Size(47, 24);
            this.EditMenu.Text = "&Edit";
            // 
            // ViewMenu
            // 
            this.ViewMenu.Name = "ViewMenu";
            this.ViewMenu.Size = new System.Drawing.Size(53, 24);
            this.ViewMenu.Text = "&View";
            // 
            // SettingsMenu
            // 
            this.SettingsMenu.Name = "SettingsMenu";
            this.SettingsMenu.Size = new System.Drawing.Size(74, 24);
            this.SettingsMenu.Text = "&Settings";
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { this.StatusLabel });
            this.statusBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.statusBar.Location = new System.Drawing.Point(0, 941);
            this.statusBar.Name = "statusBar";
            this.statusBar.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.statusBar.Size = new System.Drawing.Size(1792, 24);
            this.statusBar.TabIndex = 10;
            this.statusBar.Text = "Status";
            this.statusBar.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.statusBar_ItemClicked);
            // 
            // StatusLabel
            // 
            this.StatusLabel.BackColor = System.Drawing.Color.Red;
            this.StatusLabel.BorderStyle = System.Windows.Forms.Border3DStyle.Bump;
            this.StatusLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StatusLabel.Size = new System.Drawing.Size(141, 19);
            this.StatusLabel.Spring = true;
            this.StatusLabel.Text = "No Directory Chosen!";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.StatusLabel.ToolTipText = "Represt the current data source";
            // 
            // mainSplitter
            // 
            this.mainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainSplitter.Location = new System.Drawing.Point(0, 53);
            this.mainSplitter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mainSplitter.Name = "mainSplitter";
            // 
            // mainSplitter.Panel1
            // 
            this.mainSplitter.Panel1.Controls.Add(this.itemTree);
            // 
            // mainSplitter.Panel2
            // 
            this.mainSplitter.Panel2.Controls.Add(this.splitContainer1);
            this.mainSplitter.Panel2.Controls.Add(this.treeView1);
            this.mainSplitter.Size = new System.Drawing.Size(1792, 888);
            this.mainSplitter.SplitterDistance = 403;
            this.mainSplitter.SplitterWidth = 5;
            this.mainSplitter.TabIndex = 11;
            // 
            // itemTree
            // 
            this.itemTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.itemTree.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemTree.ImageIndex = 0;
            this.itemTree.ImageList = this.imageList1;
            this.itemTree.Location = new System.Drawing.Point(0, 0);
            this.itemTree.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.itemTree.Name = "itemTree";
            this.itemTree.SelectedImageIndex = 0;
            this.itemTree.Size = new System.Drawing.Size(403, 888);
            this.itemTree.TabIndex = 0;
            this.itemTree.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.itemTree_AfterSelect);
            this.itemTree.Click += new System.EventHandler(this.itemTree_Click);
            this.itemTree.MouseClick += new System.Windows.Forms.MouseEventHandler(this.itemTree_MouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder");
            this.imageList1.Images.SetKeyName(1, "file");
            this.imageList1.Images.SetKeyName(2, "documentselected.png");
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Location = new System.Drawing.Point(-383, 5);
            this.treeView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(360, 936);
            this.treeView1.TabIndex = 6;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.displayBox);
            this.splitContainer1.Size = new System.Drawing.Size(1384, 888);
            this.splitContainer1.SplitterDistance = 922;
            this.splitContainer1.TabIndex = 7;
            // 
            // displayBox
            // 
            this.displayBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayBox.Location = new System.Drawing.Point(0, 0);
            this.displayBox.Name = "displayBox";
            this.displayBox.Size = new System.Drawing.Size(922, 888);
            this.displayBox.TabIndex = 0;
            this.displayBox.Text = "";
            // 
            // ReaderMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1792, 965);
            this.Controls.Add(this.mainSplitter);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.topToolBar);
            this.Controls.Add(this.mainMenu);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.openButton);
            this.MainMenuStrip = this.mainMenu;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReaderMain";
            this.Text = "Proact Log Reader";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.mainSplitter.Panel1.ResumeLayout(false);
            this.mainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainSplitter)).EndInit();
            this.mainSplitter.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.RichTextBox displayBox;

        private System.Windows.Forms.SplitContainer splitContainer1;

        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;

        private System.Windows.Forms.ImageList imageList1;

        private System.Windows.Forms.ToolStripMenuItem SettingsMenu;

        private System.Windows.Forms.ToolStripMenuItem ViewMenu;

        private System.Windows.Forms.ToolStripMenuItem workingDirectoyMenu;

        private System.Windows.Forms.ToolStripMenuItem FileMenu;
        private System.Windows.Forms.ToolStripMenuItem EditMenu;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;

        private System.Windows.Forms.TreeView itemTree;

        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.SplitContainer mainSplitter;

        private System.Windows.Forms.MenuStrip mainMenu;

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ToolStrip topToolBar;

        private System.Windows.Forms.Button openButton;
        private System.Windows.Forms.Button button2;

        #endregion
    }
}