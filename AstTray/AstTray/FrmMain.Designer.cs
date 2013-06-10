namespace AstTray
{
    partial class AstTray
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AstTray));
            this.astTrayNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.callHistoryListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.callHistoryContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.callToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToMyDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.myDirectoryListView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.addDirectoryEntryBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.myDirectoryFitlerTxt = new System.Windows.Forms.ToolStripTextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.sharedDirectoryListView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.connectionStateLbl = new System.Windows.Forms.ToolStripStatusLabel();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.callHistoryContextMenu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // astTrayNotify
            // 
            this.astTrayNotify.ContextMenuStrip = this.contextMenuStrip1;
            this.astTrayNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("astTrayNotify.Icon")));
            this.astTrayNotify.Text = "AstTray";
            this.astTrayNotify.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 48);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(469, 292);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.callHistoryListView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(461, 266);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Call History";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // callHistoryListView
            // 
            this.callHistoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader7});
            this.callHistoryListView.ContextMenuStrip = this.callHistoryContextMenu;
            this.callHistoryListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.callHistoryListView.Location = new System.Drawing.Point(3, 3);
            this.callHistoryListView.Name = "callHistoryListView";
            this.callHistoryListView.Size = new System.Drawing.Size(455, 260);
            this.callHistoryListView.TabIndex = 0;
            this.callHistoryListView.UseCompatibleStateImageBehavior = false;
            this.callHistoryListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Number";
            this.columnHeader1.Width = 226;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Last Called";
            this.columnHeader2.Width = 121;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Call Type";
            // 
            // callHistoryContextMenu
            // 
            this.callHistoryContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.callToolStripMenuItem,
            this.addToMyDirectoryToolStripMenuItem});
            this.callHistoryContextMenu.Name = "callHistoryContextMenu";
            this.callHistoryContextMenu.Size = new System.Drawing.Size(182, 70);
            this.callHistoryContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.callHistoryContextMenu_Opening);
            // 
            // callToolStripMenuItem
            // 
            this.callToolStripMenuItem.Name = "callToolStripMenuItem";
            this.callToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.callToolStripMenuItem.Text = "Redial";
            // 
            // addToMyDirectoryToolStripMenuItem
            // 
            this.addToMyDirectoryToolStripMenuItem.Name = "addToMyDirectoryToolStripMenuItem";
            this.addToMyDirectoryToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.addToMyDirectoryToolStripMenuItem.Text = "Add to My Directory";
            this.addToMyDirectoryToolStripMenuItem.Click += new System.EventHandler(this.addToMyDirectoryToolStripMenuItem_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.myDirectoryListView);
            this.tabPage2.Controls.Add(this.toolStrip1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(461, 266);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "My Directory";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // myDirectoryListView
            // 
            this.myDirectoryListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.myDirectoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader6});
            this.myDirectoryListView.Location = new System.Drawing.Point(0, 31);
            this.myDirectoryListView.Name = "myDirectoryListView";
            this.myDirectoryListView.Size = new System.Drawing.Size(461, 235);
            this.myDirectoryListView.TabIndex = 1;
            this.myDirectoryListView.UseCompatibleStateImageBehavior = false;
            this.myDirectoryListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Name";
            this.columnHeader3.Width = 177;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Phone Number";
            this.columnHeader6.Width = 184;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDirectoryEntryBtn,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.myDirectoryFitlerTxt});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(455, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // addDirectoryEntryBtn
            // 
            this.addDirectoryEntryBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addDirectoryEntryBtn.Image = ((System.Drawing.Image)(resources.GetObject("addDirectoryEntryBtn.Image")));
            this.addDirectoryEntryBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addDirectoryEntryBtn.Name = "addDirectoryEntryBtn";
            this.addDirectoryEntryBtn.Size = new System.Drawing.Size(23, 22);
            this.addDirectoryEntryBtn.Text = "toolStripButton1";
            this.addDirectoryEntryBtn.Click += new System.EventHandler(this.addDirectoryEntryBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel2.Text = "Search:";
            // 
            // myDirectoryFitlerTxt
            // 
            this.myDirectoryFitlerTxt.Name = "myDirectoryFitlerTxt";
            this.myDirectoryFitlerTxt.Size = new System.Drawing.Size(100, 25);
            this.myDirectoryFitlerTxt.TextChanged += new System.EventHandler(this.toolStripTextBox2_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.toolStrip2);
            this.tabPage3.Controls.Add(this.sharedDirectoryListView);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(461, 266);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Shared Directory";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox1});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(461, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Search:";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
            // 
            // sharedDirectoryListView
            // 
            this.sharedDirectoryListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sharedDirectoryListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.sharedDirectoryListView.Location = new System.Drawing.Point(3, 28);
            this.sharedDirectoryListView.Name = "sharedDirectoryListView";
            this.sharedDirectoryListView.Size = new System.Drawing.Size(458, 242);
            this.sharedDirectoryListView.TabIndex = 0;
            this.sharedDirectoryListView.UseCompatibleStateImageBehavior = false;
            this.sharedDirectoryListView.View = System.Windows.Forms.View.Details;
            this.sharedDirectoryListView.DoubleClick += new System.EventHandler(this.sharedDirectoryListView_DoubleClick);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 200;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Telephone Number";
            this.columnHeader5.Width = 200;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStateLbl});
            this.statusStrip1.Location = new System.Drawing.Point(0, 323);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(469, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // connectionStateLbl
            // 
            this.connectionStateLbl.Name = "connectionStateLbl";
            this.connectionStateLbl.Size = new System.Drawing.Size(118, 17);
            this.connectionStateLbl.Text = "toolStripStatusLabel1";
            // 
            // AstTray
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 345);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.Name = "AstTray";
            this.Text = "AstTray";
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.callHistoryContextMenu.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon astTrayNotify;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ListView callHistoryListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ListView sharedDirectoryListView;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ToolStripStatusLabel connectionStateLbl;
        private System.Windows.Forms.ListView myDirectoryListView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripButton addDirectoryEntryBtn;
        private System.Windows.Forms.ContextMenuStrip callHistoryContextMenu;
        private System.Windows.Forms.ToolStripMenuItem callToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToMyDirectoryToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox myDirectoryFitlerTxt;
    }
}

