namespace FeedsSigma
{
	partial class EditFeedForm
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
			this.feedNameTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.atComboBox = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
			this.timeValueNumericBox = new System.Windows.Forms.NumericUpDown();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupNameComboBox = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.timeValueNumericBox)).BeginInit();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 29);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(85, 17);
			this.label1.TabIndex = 2;
			this.label1.Text = "Feed Name:";
			// 
			// feedNameTextBox
			// 
			this.feedNameTextBox.Location = new System.Drawing.Point(113, 26);
			this.feedNameTextBox.MaxLength = 256;
			this.feedNameTextBox.Name = "feedNameTextBox";
			this.feedNameTextBox.Size = new System.Drawing.Size(176, 23);
			this.feedNameTextBox.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 68);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(93, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Group Name:";
			// 
			// atComboBox
			// 
			this.atComboBox.CausesValidation = false;
			this.atComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.atComboBox.FormattingEnabled = true;
			this.atComboBox.Location = new System.Drawing.Point(113, 22);
			this.atComboBox.Name = "atComboBox";
			this.atComboBox.Size = new System.Drawing.Size(176, 24);
			this.atComboBox.TabIndex = 0;
			this.atComboBox.SelectedIndexChanged += new System.EventHandler(this.atComboBox_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(60, 67);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(47, 17);
			this.label4.TabIndex = 3;
			this.label4.Text = "every:";
			// 
			// timeValueNumericBox
			// 
			this.timeValueNumericBox.CausesValidation = false;
			this.timeValueNumericBox.Location = new System.Drawing.Point(113, 65);
			this.timeValueNumericBox.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
			this.timeValueNumericBox.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.timeValueNumericBox.Name = "timeValueNumericBox";
			this.timeValueNumericBox.Size = new System.Drawing.Size(66, 23);
			this.timeValueNumericBox.TabIndex = 1;
			this.timeValueNumericBox.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupNameComboBox);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Controls.Add(this.feedNameTextBox);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(306, 103);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Feed Info";
			// 
			// groupNameComboBox
			// 
			this.groupNameComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.groupNameComboBox.FormattingEnabled = true;
			this.groupNameComboBox.Location = new System.Drawing.Point(113, 65);
			this.groupNameComboBox.Name = "groupNameComboBox";
			this.groupNameComboBox.Size = new System.Drawing.Size(176, 24);
			this.groupNameComboBox.TabIndex = 1;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.label5);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Controls.Add(this.atComboBox);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.timeValueNumericBox);
			this.groupBox2.Location = new System.Drawing.Point(12, 121);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(306, 101);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Update Plan";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(185, 67);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(48, 17);
			this.label5.TabIndex = 4;
			this.label5.Text = "day(s)";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(79, 28);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(25, 17);
			this.label3.TabIndex = 2;
			this.label3.Text = "At:";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(162, 228);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Save";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(243, 228);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 3;
			this.button2.Text = "Close";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// EditFeedForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(331, 261);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "EditFeedForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			((System.ComponentModel.ISupportInitialize)(this.timeValueNumericBox)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox feedNameTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox atComboBox;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.NumericUpDown timeValueNumericBox;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ComboBox groupNameComboBox;
		private System.Windows.Forms.Label label5;
	}
}