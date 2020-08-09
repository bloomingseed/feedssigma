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
					try
					{
						CheckUrl();
					}
					catch(Exception err)
					{
						MessageBox.Show(this, err.Message, "URL Check Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
						throw err;
					}
				}
				Config.FeedGroups[0].Feeds.Add(NewFeed);
				openEditDialog = openEditDialogCheckBox.Checked;
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch(Exception err)
			{
				MessageBox.Show(this, err.Message, "Add Feed Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void cancelBttn_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
