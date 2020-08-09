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
			feedNameTextBox.Text = _feed.Name;
			//
			// bind group name
			//
			foreach (FeedGroup group in Config.FeedGroups)
				groupNameComboBox.Items.Add(group);
			groupNameComboBox.AutoCompleteMode = AutoCompleteMode.None;
			groupNameComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;
			groupNameComboBox.SelectedIndex = groupNameComboBox.Items.IndexOf(_feed.Group);

			//
			// bind update plan time of day combo box
			//
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
				atComboBox.SelectedIndex = atComboBox.Items.IndexOf(_feed.UpdatePlan.Item1.ToString("h':'m':'s"));
				timeValueNumericBox.Value = _feed.UpdatePlan.Item2;
			}

		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				if (CheckValidation())
				{
					string newFeedName = feedNameTextBox.Text.Trim();
					FeedGroup newGroup = groupNameComboBox.SelectedItem as FeedGroup;
					
					if (newFeedName != _feed.Name) _feed.Name = newFeedName;
					if(newGroup != _feed.Group)
					{
						_feed.Group.Feeds.Remove(_feed);
						newGroup.Feeds.Add(_feed);
					}
					if (atComboBox.SelectedIndex !=0)
					{
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
