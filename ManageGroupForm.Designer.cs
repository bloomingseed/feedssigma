namespace FeedsSigma
{
	partial class ManageGroupForm
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
			this.label1 = new System.Windows.Forms.Label();
			this.groupsComboBox = new System.Windows.Forms.ComboBox();
			this.renameTextBox = new System.Windows.Forms.TextBox();
			this.renameBttn = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.createBttn = new System.Windows.Forms.Button();
			this.closeBttn = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.newGroupTextBox = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.feedsListBox = new System.Windows.Forms.ListBox();
			this.label4 = new System.Windows.Forms.Label();
			this.desGroupComboBox = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.desFeedsListBox = new System.Windows.Forms.ListBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.forwardBttn = new System.Windows.Forms.Button();
			this.backwardBttn = new System.Windows.Forms.Button();
			this.deleteGroupBttn = new System.Windows.Forms.Button();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Group:";
			// 
			// groupsComboBox
			// 
			this.groupsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.groupsComboBox.FormattingEnabled = true;
			this.groupsComboBox.Location = new System.Drawing.Point(110, 22);
			this.groupsComboBox.Name = "groupsComboBox";
			this.groupsComboBox.Size = new System.Drawing.Size(208, 24);
			this.groupsComboBox.TabIndex = 1;
			this.groupsComboBox.SelectedIndexChanged += new System.EventHandler(this.groupsComboBox_SelectedIndexChanged);
			// 
			// renameTextBox
			// 
			this.renameTextBox.Location = new System.Drawing.Point(110, 52);
			this.renameTextBox.Name = "renameTextBox";
			this.renameTextBox.Size = new System.Drawing.Size(208, 23);
			this.renameTextBox.TabIndex = 2;
			// 
			// renameBttn
			// 
			this.renameBttn.Location = new System.Drawing.Point(243, 81);
			this.renameBttn.Name = "renameBttn";
			this.renameBttn.Size = new System.Drawing.Size(75, 23);
			this.renameBttn.TabIndex = 3;
			this.renameBttn.Text = "Rename";
			this.renameBttn.UseVisualStyleBackColor = true;
			this.renameBttn.Click += new System.EventHandler(this.renameBttn_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(22, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 17);
			this.label2.TabIndex = 4;
			this.label2.Text = "Rename:";
			// 
			// createBttn
			// 
			this.createBttn.Location = new System.Drawing.Point(234, 51);
			this.createBttn.Name = "createBttn";
			this.createBttn.Size = new System.Drawing.Size(75, 23);
			this.createBttn.TabIndex = 5;
			this.createBttn.Text = "Create";
			this.createBttn.UseVisualStyleBackColor = true;
			this.createBttn.Click += new System.EventHandler(this.createBttn_Click);
			// 
			// closeBttn
			// 
			this.closeBttn.Location = new System.Drawing.Point(620, 288);
			this.closeBttn.Name = "closeBttn";
			this.closeBttn.Size = new System.Drawing.Size(75, 23);
			this.closeBttn.TabIndex = 6;
			this.closeBttn.Text = "Close";
			this.closeBttn.UseVisualStyleBackColor = true;
			this.closeBttn.Click += new System.EventHandler(this.closeBttn_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 25);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(83, 17);
			this.label3.TabIndex = 7;
			this.label3.Text = "New Group:";
			// 
			// newGroupTextBox
			// 
			this.newGroupTextBox.Location = new System.Drawing.Point(101, 22);
			this.newGroupTextBox.Name = "newGroupTextBox";
			this.newGroupTextBox.Size = new System.Drawing.Size(208, 23);
			this.newGroupTextBox.TabIndex = 8;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.newGroupTextBox);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.createBttn);
			this.groupBox2.Location = new System.Drawing.Point(386, 12);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(320, 85);
			this.groupBox2.TabIndex = 10;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Create Group";
			// 
			// feedsListBox
			// 
			this.feedsListBox.FormattingEnabled = true;
			this.feedsListBox.HorizontalScrollbar = true;
			this.feedsListBox.ItemHeight = 16;
			this.feedsListBox.Location = new System.Drawing.Point(110, 144);
			this.feedsListBox.Name = "feedsListBox";
			this.feedsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.feedsListBox.Size = new System.Drawing.Size(208, 116);
			this.feedsListBox.Sorted = true;
			this.feedsListBox.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(22, 142);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 17);
			this.label4.TabIndex = 12;
			this.label4.Text = "Feeds:";
			// 
			// desGroupComboBox
			// 
			this.desGroupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.desGroupComboBox.FormattingEnabled = true;
			this.desGroupComboBox.Location = new System.Drawing.Point(100, 22);
			this.desGroupComboBox.Name = "desGroupComboBox";
			this.desGroupComboBox.Size = new System.Drawing.Size(208, 24);
			this.desGroupComboBox.TabIndex = 14;
			this.desGroupComboBox.SelectedIndexChanged += new System.EventHandler(this.desGroupComboBox_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(17, 25);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(52, 17);
			this.label5.TabIndex = 13;
			this.label5.Text = "Group:";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.desGroupComboBox);
			this.groupBox1.Controls.Add(this.desFeedsListBox);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Location = new System.Drawing.Point(387, 103);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(319, 179);
			this.groupBox1.TabIndex = 15;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Move Feeds";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(17, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 17);
			this.label6.TabIndex = 17;
			this.label6.Text = "Feeds:";
			// 
			// desFeedsListBox
			// 
			this.desFeedsListBox.FormattingEnabled = true;
			this.desFeedsListBox.HorizontalScrollbar = true;
			this.desFeedsListBox.ItemHeight = 16;
			this.desFeedsListBox.Location = new System.Drawing.Point(100, 52);
			this.desFeedsListBox.Name = "desFeedsListBox";
			this.desFeedsListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.desFeedsListBox.Size = new System.Drawing.Size(208, 116);
			this.desFeedsListBox.Sorted = true;
			this.desFeedsListBox.TabIndex = 16;
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.deleteGroupBttn);
			this.groupBox3.Controls.Add(this.groupsComboBox);
			this.groupBox3.Controls.Add(this.label2);
			this.groupBox3.Controls.Add(this.label4);
			this.groupBox3.Controls.Add(this.renameTextBox);
			this.groupBox3.Controls.Add(this.renameBttn);
			this.groupBox3.Controls.Add(this.feedsListBox);
			this.groupBox3.Controls.Add(this.label1);
			this.groupBox3.Location = new System.Drawing.Point(12, 12);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(325, 270);
			this.groupBox3.TabIndex = 16;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Group Info";
			// 
			// forwardBttn
			// 
			this.forwardBttn.Location = new System.Drawing.Point(343, 179);
			this.forwardBttn.Name = "forwardBttn";
			this.forwardBttn.Size = new System.Drawing.Size(38, 23);
			this.forwardBttn.TabIndex = 17;
			this.forwardBttn.Text = ">";
			this.forwardBttn.UseVisualStyleBackColor = true;
			this.forwardBttn.Click += new System.EventHandler(this.forwardBttn_Click);
			// 
			// backwardBttn
			// 
			this.backwardBttn.Location = new System.Drawing.Point(343, 232);
			this.backwardBttn.Name = "backwardBttn";
			this.backwardBttn.Size = new System.Drawing.Size(38, 23);
			this.backwardBttn.TabIndex = 18;
			this.backwardBttn.Text = "<";
			this.backwardBttn.UseVisualStyleBackColor = true;
			this.backwardBttn.Click += new System.EventHandler(this.backwardBttn_Click);
			// 
			// deleteGroupBttn
			// 
			this.deleteGroupBttn.Location = new System.Drawing.Point(162, 81);
			this.deleteGroupBttn.Name = "deleteGroupBttn";
			this.deleteGroupBttn.Size = new System.Drawing.Size(75, 23);
			this.deleteGroupBttn.TabIndex = 13;
			this.deleteGroupBttn.Text = "Delete";
			this.deleteGroupBttn.UseVisualStyleBackColor = true;
			this.deleteGroupBttn.Click += new System.EventHandler(this.deleteGroupBttn_Click);
			// 
			// ManageGroupForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(715, 320);
			this.Controls.Add(this.backwardBttn);
			this.Controls.Add(this.forwardBttn);
			this.Controls.Add(this.groupBox3);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.closeBttn);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "ManageGroupForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Manage Groups";
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox groupsComboBox;
		private System.Windows.Forms.TextBox renameTextBox;
		private System.Windows.Forms.Button renameBttn;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button createBttn;
		private System.Windows.Forms.Button closeBttn;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox newGroupTextBox;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ListBox feedsListBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox desGroupComboBox;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ListBox desFeedsListBox;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Button forwardBttn;
		private System.Windows.Forms.Button backwardBttn;
		private System.Windows.Forms.Button deleteGroupBttn;
	}
}