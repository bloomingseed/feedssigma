using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FeedsSigma
{
	public partial class MainForm : Form
	{

		private Point lastLocation;
		//private Config _config;
		private Timer timer;
		private event EventHandler FeedUpdated;
		//public MainForm(Config config)
		public MainForm()
		{
			//_config = config;
			InitializeComponent();
			//
			// load _layout.html
			webBrowser1.Navigate(string.Format("file:///{0}/web/_layout.html",
				Directory.GetCurrentDirectory().Replace("\\", "/")));
			//
			// import welcome.html into current layout
			webBrowser1.DocumentCompleted += (sender, args) => Task.Run(() => InjectHtmlContent(File.ReadAllText("web\\welcome.html")));
			//
			// auto check for update
			FeedUpdated += Notify;
			timer = new Timer();
			DateTime now = DateTime.Now;
			// The interval until next second
			timer.Interval = (int)DateTime.Parse(now.ToString("yyyy-MM-dd hh:mm:ss")).Subtract(now).TotalSeconds;
			timer.Tick += (sender, args) =>
			{
				Timer timer = sender as Timer;
				if (timer.Interval != 1000)
					timer.Interval = 1000;
				Action action = new Action(CheckFeedUpdate);
				Task.Run(action);
			};
		}

		// FeedUpdated publisher
		private void CheckFeedUpdate()
		{
			TimeSpan now = DateTime.Now.TimeOfDay;
			now = new TimeSpan(now.Hours, now.Minutes, now.Seconds);
			//foreach (var group in _config.FeedGroups)
			//	for(int i = 0; i<group.Feeds.Count; ++i)
			//		if (group.Feeds[i].UpdatePlan.HasValue && group.Feeds[i].UpdatePlan.Value == now)
			//		{
			//			//
			//			// backup lastest article's pubDate
			//			DateTime before = DateTime.Parse(group.Feeds[i].Items.First().Value["PubDate"]);
			//			//
			//			// Reload feed content from the same URL
			//			group.Feeds[i] = Feed.CreateFromUrl(group.Feeds[i].Link, group.Feeds[i].Id);
			//			//
			//			// Check if newer article presents
			//			if (DateTime.Compare(before, DateTime.Parse(group.Feeds[i].Items.First().Value["PubDate"])) < 1)
			//				FeedUpdated.Invoke(group.Feeds[i], new EventArgs());
			//		}
			FeedUpdated.Invoke(Config.FeedGroups[0].Feeds[0], new EventArgs());
		}
		// FeedUpdated handler (subscriber)
		private void Notify(object sender, EventArgs args)
		{
			//change icon
			//notifyIcon1.Icon = 
			notifyIcon1.ShowBalloonTip(3000, "Your feed has new articles", $"\"{(sender as Feed).Name}\" has been updated.",ToolTipIcon.Info);
		}
		private void MainForm_Load(object sender, System.EventArgs e)
		{
			timer.Start();
		}

		#region Handle background working
		private void showToolStripMenuItem_Click(object sender, EventArgs e)
		{
			RestoreFromSystemTray();
		}

		private void TugIntoSystemTray()
		{
			notifyIcon1.Visible = true;
			this.Visible = false;
		}
		private void RestoreFromSystemTray()
		{
			notifyIcon1.Visible = false;
			this.Visible = true;
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}
		
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			TugIntoSystemTray();
			notifyIcon1.ShowBalloonTip(3000, "Feeds Sigma is still running", "", ToolTipIcon.Info);
			e.Cancel = true;

		}
		// Close form
		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		// Minimize form
		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		#endregion
		#region Handle form moving
		private void label1_MouseDown(object sender, MouseEventArgs e)
		{
			lastLocation = e.Location;
		}

		private void label1_MouseMove(object sender, MouseEventArgs e)
		{
			if(MouseButtons.Left == e.Button)
				this.DesktopLocation = new Point(MousePosition.X - lastLocation.X, MousePosition.Y - lastLocation.Y);
		}
		#endregion


		private void InjectHtmlContent(string content)
		{
			webBrowser1.Document.Body.InnerHtml = content;
		}

		private void toolStripButton3_Click(object sender, EventArgs e)
		{
			AddFeedForm addFeedForm = new AddFeedForm();
			var result = addFeedForm.ShowDialog(this);
			if(result == DialogResult.OK)
			{

			}
		}

		private void toolStripButton2_Click(object sender, EventArgs e)
		{
			//Feed activeFeed = 
		}
	}
}
