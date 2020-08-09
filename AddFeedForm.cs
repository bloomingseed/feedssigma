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
	public partial class AddFeedForm : Form
	{
		public Feed NewFeed { get; protected set; }
		public bool openEditDialog;
		public AddFeedForm()
		{
			openEditDialog = true;
			InitializeComponent();
		}

		private void checkBttn_Click(object sender, EventArgs e)
		{
			try
			{
				CheckUrl();
				MessageBox.Show(this, "URL read fine. Click Add button to add this feed.", "URL Check Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch(Exception err)
			{
				MessageBox.Show(this, err.Message, "URL Check Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void CheckUrl()
		{
			Feed tmp = null;
			try
			{
				Uri link = new Uri(urlTextBox.Text);
				tmp = Feed.CreateFromUrl(link.AbsoluteUri, ++Config.LastFeedId);
			}
			catch (Exception err)
			{
				NewFeed = null;
				throw err;
			}
			NewFeed = tmp;
		}

		private void addBttn_Click(object sender, EventArgs e)
		{
			try
			{
				if (NewFeed == null)
				{
					CheckUrl();
				}
				while(Config.FeedGroups.Count==0)
				{
					var res = MessageBox.Show(this, "You don't have any groups yet.\r\nWould you like to create a new group manually or have a default group \"My Feeds\" created instead?", "Add Feed Warning", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
					if (res == DialogResult.Yes)
					{
						FeedGroup feedGroup = new FeedGroup(++Config.LastGroupId);
						feedGroup.Name = "My Feeds";
						Config.FeedGroups.Add(feedGroup);
					}
					else if (res == DialogResult.No)
					{
						ManageGroupForm manageGroupForm = new ManageGroupForm();
						manageGroupForm.ShowDialog(this);
					}
					else
						throw new Exception("You need to have at least 1 group to add your feed to.");
				}
				Config.FeedGroups[0].Feeds.Add(NewFeed);
				openEditDialog = openEditDialogCheckBox.Checked;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch(Exception err)
			{
				MessageBox.Show(this, err.Message, "Add Feed Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				NewFeed = null;
			}
		}

		private void cancelBttn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
