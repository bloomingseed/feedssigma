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
			//BindGroupName();

			foreach (FeedGroup group in Config.FeedGroups)
				groupNameComboBox.Items.Add(group);
			groupNameComboBox.AutoCompleteMode = AutoCompleteMode.None;
			groupNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			groupNameComboBox.SelectedIndex = groupNameComboBox.Items.IndexOf(_feed.Group);
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
					$"{hour}:0:0",
					$"{hour}:30:0"
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
				//atComboBox.SelectedItem = _feed.UpdatePlan.Item1.ToString("hh:mm:ss");
				atComboBox.SelectedIndex = atComboBox.Items.IndexOf(_feed.UpdatePlan.Item1.ToString("h':'m':'s"));
				timeValueNumericBox.Value = _feed.UpdatePlan.Item2;
			}

		}

		//private void BindGroupName()
		//{
		//	foreach (FeedGroup group in Config.FeedGroups)
		//		groupNameComboBox.Items.Add(group);
		//	groupNameComboBox.AutoCompleteMode = AutoCompleteMode.None;
		//	groupNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
		//	groupNameComboBox.SelectedIndex = groupNameComboBox.Items.IndexOf(_feed.Group);
		//}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (CheckValidation())
				{
					string newFeedName = feedNameTextBox.Text.Trim();
					FeedGroup newGroup = groupNameComboBox.SelectedItem as FeedGroup;
					
					if (newFeedName != _feed.Name) _feed.Name = newFeedName;
					//if (newGroupName != _feed.Group.Name) 
					//if(Config.FeedGroups.Find(group=>group.Name==newGroupName)==null)
					//{
					//	var res = MessageBox.Show("The group name \"" + newGroupName + "\" doesn't exist.\r\nDo you want to open \"Manage Groups\" dialog?", "Group not found", MessageBoxButtons.YesNo);
					//	if (res == DialogResult.Yes)
					//	{
					//		//FeedGroup group = new FeedGroup(++Config.LastGroupId);
					//		//group.Name = groupName;
					//		//group.Feeds.Add(_feed);
					//		//_feed.Group.Feeds.Remove(_feed);
					//		//Config.FeedGroups.Add(group);
					//		(new ManageGroupForm(_feed.Group)).ShowDialog(this);
					//		BindGroupName();
					//	}
					//	else
					//		throw new Exception("Then please enter an existed group name.");
					//}
					if(newGroup != _feed.Group)
					{
						_feed.Group.Feeds.Remove(_feed);
						newGroup.Feeds.Add(_feed);
					}
					if (atComboBox.SelectedIndex !=0)
					{
						//string[] timeComps = atComboBox.Text.Split(':');
						//TimeSpan newTime = new TimeSpan(int.Parse(timeComps[0]), int.Parse(timeComps[1]), 0);
						//_feed.UpdatePlan = new Tuple<TimeSpan, int>(newTime, (int)timeValueNumericBox.Value);
						_feed.UpdatePlan = new Tuple<TimeSpan, int>(TimeSpan.Parse(atComboBox.SelectedItem.ToString()), (int)timeValueNumericBox.Value);
					}
					MessageBox.Show(this, "Changes saved.", "Edit Feed Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch (Exception err) { MessageBox.Show(this, err.Message, "Edit Form Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

		}

		private bool CheckValidation()
		{
			//
			// Validate Feed Name
			if (String.IsNullOrEmpty(feedNameTextBox.Text) || String.IsNullOrWhiteSpace(feedNameTextBox.Text))
				throw new Exception("Please fill in feed name.");
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
