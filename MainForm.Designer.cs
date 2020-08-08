namespace FeedsSigma
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.addFeedBttn = new System.Windows.Forms.ToolStripButton();
			this.deleteFeedBttn = new System.Windows.Forms.ToolStripButton();
			this.manualRefreshBttn = new System.Windows.Forms.ToolStripButton();
			this.editFeedBttn = new System.Windows.Forms.ToolStripButton();
			this.manageGroupsBttn = new System.Windows.Forms.ToolStripButton();
			this.windowToolStrip = new System.Windows.Forms.ToolStrip();
			this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripLabel5 = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.closeBttn = new System.Windows.Forms.ToolStripButton();
			this.restoreBttn = new System.Windows.Forms.ToolStripButton();
			this.minimizeBttn = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.webBrowser1 = new System.Windows.Forms.WebBrowser();
			this.contextMenuStrip1.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.windowToolStrip.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.notifyIcon1.BalloonTipText = "Double click to show interface";
			this.notifyIcon1.BalloonTipTitle = "FeedsSigma";
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "FeedsSigma";
			this.notifyIcon1.Visible = true;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
			// 
			// showToolStripMenuItem
			// 
			this.showToolStripMenuItem.Name = "showToolStripMenuItem";
			this.showToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.showToolStripMenuItem.Text = "Show";
			this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
			// 
			// toolStrip1
			// 
			this.toolStrip1.BackColor = System.Drawing.SystemColors.MenuBar;
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFeedBttn,
            this.deleteFeedBttn,
            this.manualRefreshBttn,
            this.editFeedBttn,
            this.manageGroupsBttn});
			this.toolStrip1.Location = new System.Drawing.Point(0, 546);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(800, 54);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// addFeedBttn
			// 
			this.addFeedBttn.Image = global::FeedsSigma.Properties.Resources.plus;
			this.addFeedBttn.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.addFeedBttn.Name = "addFeedBttn";
			this.addFeedBttn.Size = new System.Drawing.Size(61, 51);
			this.addFeedBttn.Text = "Add Feed";
			this.addFeedBttn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.addFeedBttn.Click += new System.EventHandler(this.addFeedBttn_Click);
			// 
			// deleteFeedBttn
			// 
			this.deleteFeedBttn.Image = global::FeedsSigma.Properties.Resources.trash;
			this.deleteFeedBttn.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.deleteFeedBttn.Name = "deleteFeedBttn";
			this.deleteFeedBttn.Size = new System.Drawing.Size(72, 51);
			this.deleteFeedBttn.Text = "Delete Feed";
			this.deleteFeedBttn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.deleteFeedBttn.Click += new System.EventHandler(this.deleteFeedBttn_Click);
			// 
			// manualRefreshBttn
			// 
			this.manualRefreshBttn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
			this.manualRefreshBttn.Image = ((System.Drawing.Image)(resources.GetObject("manualRefreshBttn.Image")));
			this.manualRefreshBttn.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.manualRefreshBttn.Name = "manualRefreshBttn";
			this.manualRefreshBttn.Size = new System.Drawing.Size(93, 51);
			this.manualRefreshBttn.Text = "Manual Refresh";
			this.manualRefreshBttn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.manualRefreshBttn.Click += new System.EventHandler(this.manualRefreshBttn_Click);
			// 
			// editFeedBttn
			// 
			this.editFeedBttn.Image = global::FeedsSigma.Properties.Resources.compose;
			this.editFeedBttn.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.editFeedBttn.Name = "editFeedBttn";
			this.editFeedBttn.Size = new System.Drawing.Size(83, 51);
			this.editFeedBttn.Text = "Edit This Feed";
			this.editFeedBttn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.editFeedBttn.Click += new System.EventHandler(this.editFeedBttn_Click);
			// 
			// manageGroupsBttn
			// 
			this.manageGroupsBttn.Image = global::FeedsSigma.Properties.Resources.menu;
			this.manageGroupsBttn.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.manageGroupsBttn.Name = "manageGroupsBttn";
			this.manageGroupsBttn.Size = new System.Drawing.Size(95, 51);
			this.manageGroupsBttn.Text = "Manage Groups";
			this.manageGroupsBttn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
			this.manageGroupsBttn.Click += new System.EventHandler(this.manageGroupsBttn_Click);
			// 
			// windowToolStrip
			// 
			this.windowToolStrip.BackColor = System.Drawing.SystemColors.MenuBar;
			this.windowToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.windowToolStrip.ImageScalingSize = new System.Drawing.Size(48, 48);
			this.windowToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel3,
            this.toolStripLabel4,
            this.toolStripLabel5,
            this.toolStripSeparator2,
            this.closeBttn,
            this.restoreBttn,
            this.minimizeBttn});
			this.windowToolStrip.Location = new System.Drawing.Point(0, 0);
			this.windowToolStrip.Name = "windowToolStrip";
			this.windowToolStrip.Size = new System.Drawing.Size(800, 51);
			this.windowToolStrip.TabIndex = 6;
			this.windowToolStrip.Text = "windowToolStrip";
			this.windowToolStrip.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label1_MouseDown);
			this.windowToolStrip.MouseMove += new System.Windows.Forms.MouseEventHandler(this.label1_MouseMove);
			this.windowToolStrip.MouseUp += new System.Windows.Forms.MouseEventHandler(this.windowToolStrip_MouseUp);
			// 
			// toolStripLabel3
			// 
			this.toolStripLabel3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripLabel3.Name = "toolStripLabel3";
			this.toolStripLabel3.Size = new System.Drawing.Size(0, 48);
			this.toolStripLabel3.Text = "toolStripLabel3";
			// 
			// toolStripLabel4
			// 
			this.toolStripLabel4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripLabel4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripLabel4.Image")));
			this.toolStripLabel4.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.toolStripLabel4.Name = "toolStripLabel4";
			this.toolStripLabel4.Size = new System.Drawing.Size(48, 48);
			this.toolStripLabel4.Text = "toolStripLabel4";
			// 
			// toolStripLabel5
			// 
			this.toolStripLabel5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripLabel5.Font = new System.Drawing.Font("Segoe Print", 9F, System.Drawing.FontStyle.Bold);
			this.toolStripLabel5.Name = "toolStripLabel5";
			this.toolStripLabel5.Size = new System.Drawing.Size(84, 48);
			this.toolStripLabel5.Text = "Feeds Sigma";
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 51);
			// 
			// closeBttn
			// 
			this.closeBttn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.closeBttn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.closeBttn.Image = ((System.Drawing.Image)(resources.GetObject("closeBttn.Image")));
			this.closeBttn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.closeBttn.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.closeBttn.Name = "closeBttn";
			this.closeBttn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.closeBttn.Size = new System.Drawing.Size(36, 48);
			this.closeBttn.Text = "toolStripButton1";
			this.closeBttn.ToolTipText = "Close";
			this.closeBttn.Click += new System.EventHandler(this.closeBttn_Click);
			// 
			// restoreBttn
			// 
			this.restoreBttn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.restoreBttn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.restoreBttn.Image = ((System.Drawing.Image)(resources.GetObject("restoreBttn.Image")));
			this.restoreBttn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.restoreBttn.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.restoreBttn.Name = "restoreBttn";
			this.restoreBttn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.restoreBttn.Size = new System.Drawing.Size(36, 48);
			this.restoreBttn.Text = "toolStripButton2";
			this.restoreBttn.ToolTipText = "Expand";
			this.restoreBttn.Click += new System.EventHandler(this.restoreBttn_Click);
			// 
			// minimizeBttn
			// 
			this.minimizeBttn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
			this.minimizeBttn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.minimizeBttn.Image = ((System.Drawing.Image)(resources.GetObject("minimizeBttn.Image")));
			this.minimizeBttn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
			this.minimizeBttn.ImageTransparentColor = System.Drawing.Color.Transparent;
			this.minimizeBttn.Name = "minimizeBttn";
			this.minimizeBttn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
			this.minimizeBttn.Size = new System.Drawing.Size(36, 48);
			this.minimizeBttn.Text = "toolStripButton3";
			this.minimizeBttn.ToolTipText = "Minimize";
			this.minimizeBttn.Click += new System.EventHandler(this.minimizeBttn_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 51);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.listView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
			this.splitContainer1.Size = new System.Drawing.Size(800, 495);
			this.splitContainer1.SplitterDistance = 246;
			this.splitContainer1.TabIndex = 7;
			// 
			// listView1
			// 
			this.listView1.BackColor = System.Drawing.SystemColors.InactiveBorder;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.listView1.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listView1.HideSelection = false;
			this.listView1.Location = new System.Drawing.Point(0, 0);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(246, 495);
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 0;
			this.listView1.UseCompatibleStateImageBehavior = false;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "#ID. Name";
			this.columnHeader1.Width = 155;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Last Checked";
			this.columnHeader2.Width = 87;
			// 
			// webBrowser1
			// 
			this.webBrowser1.AllowWebBrowserDrop = false;
			this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.webBrowser1.Location = new System.Drawing.Point(0, 0);
			this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
			this.webBrowser1.Name = "webBrowser1";
			this.webBrowser1.Size = new System.Drawing.Size(550, 495);
			this.webBrowser1.TabIndex = 0;
			this.webBrowser1.WebBrowserShortcutsEnabled = false;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 600);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.windowToolStrip);
			this.Controls.Add(this.toolStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(800, 600);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Feeds Sigma Client";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.windowToolStrip.ResumeLayout(false);
			this.windowToolStrip.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}


		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton addFeedBttn;
		private System.Windows.Forms.ToolStripButton manualRefreshBttn;
		private System.Windows.Forms.ToolStripButton manageGroupsBttn;
		private System.Windows.Forms.ToolStripButton deleteFeedBttn;
		private System.Windows.Forms.ToolStrip windowToolStrip;
		private System.Windows.Forms.ToolStripLabel toolStripLabel3;
		private System.Windows.Forms.ToolStripLabel toolStripLabel4;
		private System.Windows.Forms.ToolStripLabel toolStripLabel5;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton closeBttn;
		private System.Windows.Forms.ToolStripButton restoreBttn;
		private System.Windows.Forms.ToolStripButton minimizeBttn;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.WebBrowser webBrowser1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ToolStripButton editFeedBttn;
	}
}

