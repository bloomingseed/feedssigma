using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedsSigma
{
	public partial class AddGroupForm : Form
	{
		//private Config Config;
		public FeedGroup FeedGroup { get; set; }
		//public AddGroupForm(Config config)
		public AddGroupForm()
		{
			//Config = config;
			InitializeComponent();
			BindAutoComplete();
		}

		private void BindAutoComplete()
		{
			AutoCompleteStringCollection groupNames = new AutoCompleteStringCollection();
			foreach (var group in Config.FeedGroups)
				groupNames.Add(group.Name);
			groupsTextBox.AutoCompleteCustomSource = groupNames;
		}
		private void addButton_Click(object sender, EventArgs e)
		{
			if (groupsTextBox.AutoCompleteCustomSource.Contains(groupsTextBox.Text))
			{
				MessageBox.Show(this, $"The group name \"{groupsTextBox.Text}\" has already existed.\r\nPlease choose a different name.");

			}
			else
			{
				FeedGroup = new FeedGroup(++Config.LastGroupId);
				FeedGroup.Name = groupsTextBox.Text;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
