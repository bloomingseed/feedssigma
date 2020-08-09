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
	public partial class ManageGroupForm : Form
	{
		private FeedGroup activeGroup;
		
		public ManageGroupForm(FeedGroup group = null)
		{
			activeGroup = group;
			InitializeComponent();
			// bind auto completing
			this.Load += BindGroups;
			renameBttn.Click += BindGroups;
			createBttn.Click += BindGroups;
			deleteGroupBttn.Click += BindGroups;

		}

		private void BindGroups(object sender, EventArgs args)
		{
			AutoCompleteStringCollection src = new AutoCompleteStringCollection();
			groupsComboBox.Items.Clear();
			desGroupComboBox.Items.Clear();
			foreach (FeedGroup group in Config.FeedGroups)
			{
				groupsComboBox.Items.Add(group);
				desGroupComboBox.Items.Add(group);
				src.Add(group.Name);
			}
			groupsComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			groupsComboBox.AutoCompleteMode = AutoCompleteMode.None;

			groupsComboBox.SelectedIndex = activeGroup != null ? groupsComboBox.Items.IndexOf(activeGroup) : groupsComboBox.Items.Count - 1;
			if (groupsComboBox.Items.Count > 0)
			{
				desGroupComboBox.Items.RemoveAt(groupsComboBox.SelectedIndex);
				src.RemoveAt(groupsComboBox.SelectedIndex);
			}

			renameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
			renameTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
			renameTextBox.AutoCompleteCustomSource = src;
			newGroupTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
			newGroupTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
			newGroupTextBox.AutoCompleteCustomSource = src;
			renameTextBox.Text = activeGroup != null ? activeGroup.Name : "";
			newGroupTextBox.Text = "";
			if (src.Count == 0)
			{

				desGroupComboBox.Enabled = desFeedsListBox.Enabled = forwardBttn.Enabled = backwardBttn.Enabled = false;
			}
			else
			{

				desGroupComboBox.Enabled = desFeedsListBox.Enabled = forwardBttn.Enabled = backwardBttn.Enabled = true;
				
				desGroupComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
				desGroupComboBox.AutoCompleteMode = AutoCompleteMode.None;
			}
		}

		private void closeBttn_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void groupsComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (groupsComboBox.SelectedIndex >= 0)
			{
				activeGroup = groupsComboBox.SelectedItem as FeedGroup;
				BindFeedsListBox();
			}
		}

		private void BindFeedsListBox()
		{
			if (groupsComboBox.SelectedIndex >= 0)
			{
				feedsListBox.Items.Clear();
				foreach (Feed feed in (groupsComboBox.SelectedItem as FeedGroup).Feeds)
					feedsListBox.Items.Add(feed);
			}
		}

		private void desGroupComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (groupsComboBox.SelectedIndex >= 0)
			{
				BindDesFeedsListBox();
			}
		}
		private void BindDesFeedsListBox()
		{
			if (desGroupComboBox.SelectedIndex >= 0)
			{
				desFeedsListBox.Items.Clear();
				foreach (Feed feed in (desGroupComboBox.SelectedItem as FeedGroup).Feeds)
					desFeedsListBox.Items.Add(feed);
			}
		}
		private void renameBttn_Click(object sender, EventArgs e)
		{
			string name = renameTextBox.Text.Trim();
			FeedGroup group = groupsComboBox.SelectedItem as FeedGroup;

			if (String.IsNullOrEmpty(name) || String.IsNullOrWhiteSpace(name))
				MessageBox.Show(this, "Group name is empty.", "Rename Group Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			else if (name == group.Name)
				MessageBox.Show(this, "New name is the same as before.", "Rename Group Canceled",MessageBoxButtons.OK,MessageBoxIcon.Information);
			else
			{
				group.Name = name;
				MessageBox.Show(this, "Changed group name to\""+name+"\".","Rename Group Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			
		}

		private void createBttn_Click(object sender, EventArgs e)
		{
			string name = newGroupTextBox.Text.Trim();
			try
			{
				if (!String.IsNullOrEmpty(name) || !String.IsNullOrWhiteSpace(name)
					&& MessageBox.Show(this, "Create a group named \"" + name + "\"?", "Create Group", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					if (Config.FeedGroups.Find(group => group.Name == name) != null
						&& MessageBox.Show(this, $"The name \"{name}\" has existed.\r\nDo you want to create new group with this name anyway?", "Create Group Name Conflict", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
						throw new Exception("The name \"" + name + "\" has existed. Please choose another name.");
					FeedGroup newGroup = new FeedGroup(++Config.LastGroupId);
					newGroup.Name = name;
					Config.FeedGroups.Add(newGroup);
					MessageBox.Show(this, "New group \"" + newGroup.ToString() + "\" has been created.", "Create Group Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			catch(Exception err) { MessageBox.Show(this, err.Message, "Create Group Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
		}

		private void forwardBttn_Click(object sender, EventArgs e)
		{
			if (feedsListBox.SelectedItems.Count > 0
				&& desGroupComboBox.SelectedIndex >= 0)
			{
				string msg = $"Move {feedsListBox.SelectedItems.Count} items from \"{groupsComboBox.SelectedItem.ToString()}\" to \"{desGroupComboBox.SelectedItem.ToString()}\" ?";
				if (MessageBox.Show(this, msg, "Move Feeds", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					var from = feedsListBox.SelectedItems;
					FeedGroup to = desGroupComboBox.SelectedItem as FeedGroup;
					foreach (var feedItem in from)
					{
						Feed feed = feedItem as Feed;
						feed.Group.Feeds.Remove(feed);
						to.Feeds.Add(feed);
					}
					BindFeedsListBox();
					BindDesFeedsListBox();
				}
			}
		}

		private void backwardBttn_Click(object sender, EventArgs e)
		{
			if (desFeedsListBox.SelectedItems.Count > 0
				&& groupsComboBox.SelectedIndex>=0)
			{
				string msg = $"Move {desFeedsListBox.SelectedItems.Count} items from \"{desGroupComboBox.SelectedItem.ToString()}\" to \"{groupsComboBox.SelectedItem.ToString()}\" ?";
				if (MessageBox.Show(this, msg, "Move Feeds", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
				{
					var from = desFeedsListBox.SelectedItems;
					FeedGroup to = groupsComboBox.SelectedItem as FeedGroup;
					foreach (var feedItem in from)
					{
						Feed feed = feedItem as Feed;
						feed.Group.Feeds.Remove(feed);
						to.Feeds.Add(feed);
					}
					BindFeedsListBox();
					BindDesFeedsListBox();
				}
			}
		}

		private void deleteGroupBttn_Click(object sender, EventArgs e)
		{
			if (groupsComboBox.SelectedIndex >= 0
				&& MessageBox.Show(this,"Deleting a whole group will also delete all of its feeds.\r\nDo you want to continue?","Delete Group Warning",MessageBoxButtons.YesNo,MessageBoxIcon.Warning) == DialogResult.Yes)
			{
				FeedGroup group = groupsComboBox.SelectedItem as FeedGroup;
				group.Feeds.Clear();
				Config.FeedGroups.Remove(group);
				activeGroup = null;
			}
		}
	}
}
