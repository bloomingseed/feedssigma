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
		//private Config Config;
		//public AddFeedForm(Config config)
		public AddFeedForm()
		{
			//Config = config;
			InitializeComponent();
			BindComboBoxes();
		}
		private void BindComboBoxes()
		{
			AutoCompleteStringCollection groupNames = new AutoCompleteStringCollection(),
			timeOfDay = new AutoCompleteStringCollection();
			foreach (var group in Config.FeedGroups)
				groupNames.Add(group.Name);
			groupsComboBox.AutoCompleteCustomSource = groupNames;
			for(int i = 0; i<24; ++i)
			{
				timeOfDay.AddRange(new string[]
				{
					$"{((i<10)?"0"+i.ToString():i.ToString())}:00",
					$"{((i<10)?"0"+i.ToString():i.ToString())}:30"
				});
			}
			plansComboBox.AutoCompleteCustomSource = timeOfDay;
		}

		private void button1_Click(object sender, EventArgs e)
		{

		}

		private void button2_Click(object sender, EventArgs e)
		{
			
		}
	}
}
