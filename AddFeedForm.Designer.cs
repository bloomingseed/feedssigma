namespace FeedsSigma
{
	partial class AddFeedForm
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
			this.checkBttn = new System.Windows.Forms.Button();
			this.urlTextBox = new System.Windows.Forms.TextBox();
			this.cancelBttn = new System.Windows.Forms.Button();
			this.addBttn = new System.Windows.Forms.Button();
			this.openEditDialogCheckBox = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(16, 18);
			this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(76, 17);
			this.label1.TabIndex = 0;
			this.label1.Text = "Feed URL:";
			// 
			// checkBttn
			// 
			this.checkBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.checkBttn.Location = new System.Drawing.Point(697, 17);
			this.checkBttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.checkBttn.Name = "checkBttn";
			this.checkBttn.Size = new System.Drawing.Size(100, 28);
			this.checkBttn.TabIndex = 1;
			this.checkBttn.Text = "Check";
			this.checkBttn.UseVisualStyleBackColor = true;
			this.checkBttn.Click += new System.EventHandler(this.checkBttn_Click);
			// 
			// urlTextBox
			// 
			this.urlTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.urlTextBox.Location = new System.Drawing.Point(100, 18);
			this.urlTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.urlTextBox.Name = "urlTextBox";
			this.urlTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
			this.urlTextBox.Size = new System.Drawing.Size(589, 23);
			this.urlTextBox.TabIndex = 2;
			// 
			// cancelBttn
			// 
			this.cancelBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cancelBttn.Location = new System.Drawing.Point(697, 64);
			this.cancelBttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.cancelBttn.Name = "cancelBttn";
			this.cancelBttn.Size = new System.Drawing.Size(100, 28);
			this.cancelBttn.TabIndex = 11;
			this.cancelBttn.Text = "Cancel";
			this.cancelBttn.UseVisualStyleBackColor = true;
			this.cancelBttn.Click += new System.EventHandler(this.cancelBttn_Click);
			// 
			// addBttn
			// 
			this.addBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addBttn.Location = new System.Drawing.Point(589, 64);
			this.addBttn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.addBttn.Name = "addBttn";
			this.addBttn.Size = new System.Drawing.Size(100, 28);
			this.addBttn.TabIndex = 12;
			this.addBttn.Text = "Add";
			this.addBttn.UseVisualStyleBackColor = true;
			this.addBttn.Click += new System.EventHandler(this.addBttn_Click);
			// 
			// openEditDialogCheckBox
			// 
			this.openEditDialogCheckBox.AutoSize = true;
			this.openEditDialogCheckBox.Checked = true;
			this.openEditDialogCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
			this.openEditDialogCheckBox.Location = new System.Drawing.Point(386, 69);
			this.openEditDialogCheckBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.openEditDialogCheckBox.Name = "openEditDialogCheckBox";
			this.openEditDialogCheckBox.Size = new System.Drawing.Size(195, 21);
			this.openEditDialogCheckBox.TabIndex = 13;
			this.openEditDialogCheckBox.Text = "Open Edit dialog afterward";
			this.openEditDialogCheckBox.UseVisualStyleBackColor = true;
			// 
			// AddFeedForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(805, 105);
			this.Controls.Add(this.openEditDialogCheckBox);
			this.Controls.Add(this.addBttn);
			this.Controls.Add(this.cancelBttn);
			this.Controls.Add(this.urlTextBox);
			this.Controls.Add(this.checkBttn);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.Name = "AddFeedForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Add New Feed";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button checkBttn;
		private System.Windows.Forms.TextBox urlTextBox;
		private System.Windows.Forms.Button cancelBttn;
		private System.Windows.Forms.Button addBttn;
		private System.Windows.Forms.CheckBox openEditDialogCheckBox;
	}
}