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
	public partial class EditFeedForm : Form
	{
		public Feed _feed;
		public EditFeedForm(Feed feed)
		{
			_feed = feed;
			InitializeComponent();
			this.Text = "Edit " + _feed.Name;
			//
			// bind feed name text box
			feedNameTextBox.Text = _feed.Name;
			//
			// bind group name
			//AutoCompleteStringCollection groupNames = new AutoCompleteStringCollection();
			//foreach (FeedGroup group in Config.FeedGroups)
			//	groupNames.Add(group.Name);

			//groupNameComboBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			//groupNameComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
			//groupNameComboBox.AutoCompleteCustomSource = groupNames;
			//foreach (FeedGroup group in Config.FeedGroups)
			//	groupNameComboBox.Items.Add(group.Name);
			//groupNameComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
			//groupNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			//groupNameComboBox.SelectedItem = _feed.Group.Name;
			BindGroupName();
			//groupNameTextBox.Text = _feed.Group.Name;

			//
			// bind update plan time of day combo box
			//AutoCompleteStringCollection src = new AutoCompleteStringCollection();
			//src.Add("Never");
			//for(int hour = 0; hour<24; ++hour)
			//	src.AddRange(new string[] {
			//		$"{hour}:00:00",
			//		$"{hour}:30:00"
			//	});
			atComboBox.Items.Add("Never");
			for (int hour = 0; hour < 24; ++hour)
				atComboBox.Items.AddRange(new string[] {
					$"{hour}:00:00",
					$"{hour}:30:00"
				});
			atComboBox.AutoCompleteMode = AutoCompleteMode.None;
			atComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			if (_feed.UpdatePlan == null)
			{
				atComboBox.SelectedIndex = 0;
				timeValueNumericBox.Enabled = false;
			}
			else
			{
				atComboBox.SelectedItem = _feed.UpdatePlan.Item1.ToString("hh:mm:ss");
				timeValueNumericBox.Value = _feed.UpdatePlan.Item2;
			}

		}

		private void BindGroupName()
		{
			foreach (FeedGroup group in Config.FeedGroups)
				groupNameComboBox.Items.Add(group.Name);
			groupNameComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
			groupNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			groupNameComboBox.SelectedItem = _feed.Group.Name;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (CheckValidation())
				{
					string newFeedName = feedNameTextBox.Text.Trim(),
						newGroupName = groupNameComboBox.Text.Trim();
					
					if (newFeedName != _feed.Name) _feed.Name = newFeedName;
					if (newGroupName != _feed.Group.Name) 
					{
						var res = MessageBox.Show("The group name \"" + newGroupName + "\" doesn't exist.\r\nDo you want to open \"Manage Groups\" dialog?", "Group not found", MessageBoxButtons.YesNo);
						if (res == DialogResult.Yes)
						{
							//FeedGroup group = new FeedGroup(++Config.LastGroupId);
							//group.Name = groupName;
							//group.Feeds.Add(_feed);
							//_feed.Group.Feeds.Remove(_feed);
							//Config.FeedGroups.Add(group);
							(new ManageGroupForm(_feed.Group)).ShowDialog(this);
							BindGroupName();
						}
						else
							throw new Exception("Please enter an existed group name.");
					}
					if (atComboBox.SelectedIndex == 0) _feed.UpdatePlan = null;
					else
					{
						string[] timeComps = atComboBox.Text.Split(':');
						TimeSpan newTime = new TimeSpan(int.Parse(timeComps[0]), int.Parse(timeComps[1]), 0);
						_feed.UpdatePlan = new Tuple<TimeSpan, int>(newTime, (int)timeValueNumericBox.Value);
					}
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch (Exception err) { MessageBox.Show(err.Message); }

		}

		private bool CheckValidation()
		{
			//
			// Validate Feed Name
			if (String.IsNullOrEmpty(feedNameTextBox.Text) || String.IsNullOrWhiteSpace(feedNameTextBox.Text))
				throw new Exception("Please fill in feed name.");
			//
			// Validate Group Name
			if (String.IsNullOrEmpty(groupNameComboBox.Text) || String.IsNullOrWhiteSpace(groupNameComboBox.Text))
				throw new Exception("Please fill in group name.");
			return true;
		}

		private void button2_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}

		private void atComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (atComboBox.SelectedIndex == 0)
				timeValueNumericBox.Enabled = false;
			else
				timeValueNumericBox.Enabled = true;
		}
	}
}
