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
using FeedsSigma.Properties;
using System.Xml;
using System.Xml.Linq;

namespace FeedsSigma
{
	public partial class MainForm : Form
	{
		private bool hasUpdate;
		private Point? lastLocation;
		private Timer timer;
		private event EventHandler FeedUpdated;
		private List<ListViewItem> _notifiedItems;
		public MainForm()
		{
			_notifiedItems = new List<ListViewItem>();
			InitializeComponent();
			//
			// set up image list for listview items
			//
			ImageList imageList = new ImageList();
			imageList.Images.Add("rss", Resources.rss);
			imageList.Images.Add("rss_notified", Resources.rss_notified);
			//imageList.ImageSize = new Size(28, 28);
			listView1.SmallImageList = imageList;
			//
			// bind items to view
			//
			BindListView();
			//
			// check update every minute
			//
			timer = new Timer();
			timer.Tick += (sender, args) =>
			{
				Timer timer = sender as Timer;
				if (timer.Interval != 60000)
					timer.Interval = 60000;
				Action action = new Action(CheckFeedUpdate);
				Task.Run(action);
			};
			//
			// notify when a feed has new content
			//
			FeedUpdated += Notify;
		}

		private void BindListView()
		{
			listView1.Clear();
			listView1.Groups.Clear();
			listView1.Columns.AddRange(new ColumnHeader[]
			{
				new ColumnHeader()
				{
					Text="#ID. Name",
					Width=155
				},
				new ColumnHeader()
				{
					Text="Last Checked",
					Width=87
				}
			});
			foreach (FeedGroup feedGroup in Config.FeedGroups)
			{
				ListViewGroup viewGroup = new ListViewGroup(feedGroup.ToString());
				foreach(Feed feed in feedGroup.Feeds)
				{
					ListViewItem feedItem = new ListViewItem();
					//feedItem.Text = feed.Id.ToString();
					feedItem.Text = feed.ToString();
					feedItem.ImageKey = "rss";
					feedItem.Tag = feed;
					feedItem.SubItems.Add(feed.LastChecked.ToString());
					feedItem.SubItems.Add("seen");
					viewGroup.Items.Add(feedItem);
					listView1.Items.Add(feedItem);
				}
				if (viewGroup.Items.Count == 0)
					viewGroup.Items.Add("");
				listView1.Groups.Add(viewGroup);
			}
			
		}

		// FeedUpdated publisher
		private void CheckFeedUpdate()
		{
			DateTime now = DateTime.Now;
			//foreach (var group in Config.FeedGroups)
			//	for (int i = 0; i < group.Feeds.Count; ++i) {
			foreach(ListViewGroup group in listView1.Groups)
				foreach(ListViewItem feedItem in group.Items)
				{
					if (feedItem.Text != "")
					{
						Feed iFeed = feedItem.Tag as Feed;

						//if (iFeed.UpdatePlan.HasValue && iFeed.UpdatePlan.Value == now)
						if (iFeed.UpdatePlan != null &&
									DateTime.Compare(new DateTime(iFeed.LastChecked.Year, iFeed.LastChecked.Month, iFeed.LastChecked.Day + iFeed.UpdatePlan.Item2,
																	iFeed.UpdatePlan.Item1.Hours, iFeed.UpdatePlan.Item1.Minutes, 0)
													, now) <= 0)
						{
							Task.Run(() => { UpdateFeed(feedItem); });
						}
					}
				}
	}

		private void UpdateFeed(ListViewItem feedItem)
		{
			Feed feed = feedItem.Tag as Feed;
			string timeKey = "PubDate";
			if (feed.Standard == "atom")
				timeKey = "Updated";
			//backup lastest article's pubdate
			DateTime before = DateTime.Parse(feed.Items.First().Value[timeKey]);

			//reload feed content from the same url
			feed = Feed.CreateFromUrl(feed.Link, feed.Id);

			//check if newer article presents
			if (DateTime.Compare(before, DateTime.Parse(feed.Items.First().Value[timeKey])) < 1)
			{
				FeedUpdated.Invoke(feedItem, new EventArgs());
			}
		}
		private void Notify(object sender, EventArgs args)
		{
			//change icon
			ListViewItem feedItem = sender as ListViewItem;
			notifyIcon1.Icon = Resources.trans_logo_notified;
			feedItem.SubItems[2].Text = "unseen";
			feedItem.ImageKey = "rss_notified";
			_notifiedItems.Add(feedItem);

			notifyIcon1.ShowBalloonTip(3000, $"\"{feedItem.Name}\" has new articles.", "Feed Updated",ToolTipIcon.Info);
			hasUpdate = true;
		}
		private void TryTurnOffNotified()
		{
			if (_notifiedItems.Count == 0)
				notifyIcon1.Icon = Resources.trans_logo_icon;
		}
		private void MainForm_Load(object sender, System.EventArgs e)
		{
			//
			// load _layout.html
			//webBrowser1.Navigate("file:///" + Environment.CurrentDirectory.Replace("\\", "/") + "/dev.xml");
			webBrowser1.Navigate(string.Format("file:///{0}/web/_layout.html",
				Directory.GetCurrentDirectory().Replace("\\", "/")));
			//
			// import welcome.html into current layout
			webBrowser1.DocumentCompleted += (obj, args) => Task.Run(() => InjectHtmlContent(File.ReadAllText("web\\welcome.html")));
			//
			// Start timer tick at next minute
			timer.Interval = 60000 - DateTime.Now.Second*1000 - DateTime.Now.Millisecond;
			timer.Start();
			//Task.Run(StartTimer);
		}

		#region Handle background working
		private void showToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if(this.Visible == false)
				this.Visible = true;
			if (hasUpdate)
				notifyIcon1.Icon = Resources.trans_logo_icon;
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			timer.Stop();
			this.Dispose();
		}
		
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			this.Visible = false;
			notifyIcon1.ShowBalloonTip(3000, "Feeds Sigma is still running", "Right click the Feeds Sigma icon in the system tray and choose to quit to program.", ToolTipIcon.Info);
			e.Cancel = true;

		}
		private void closeBttn_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void minimizeBttn_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}
		private void restoreBttn_Click(object sender, EventArgs e)
		{
			if (this.WindowState != FormWindowState.Maximized)
			{
				this.WindowState = FormWindowState.Maximized;
				restoreBttn.ToolTipText = "Restore";
			}
			else
			{
				this.WindowState = FormWindowState.Normal;
				restoreBttn.ToolTipText = "Expand";
			}
		}
		#endregion
		#region Handle form moving
		private void label1_MouseDown(object sender, MouseEventArgs e)
		{
			lastLocation = e.Location;
		}

		private void label1_MouseMove(object sender, MouseEventArgs e)
		{
			if(lastLocation.HasValue)
				this.DesktopLocation = new Point(MousePosition.X - lastLocation.Value.X, MousePosition.Y - lastLocation.Value.Y);
		}
		private void windowToolStrip_MouseUp(object sender, MouseEventArgs e)
		{
			lastLocation = null;
		}
		#endregion


		private void InjectHtmlContent(string content)
		{
			//webBrowser1.Navigate("about:blank");
			//XDocument xFile = XDocument.Load("web\\_layout.html");
			//xFile.Descendants(XName.Get("body", xFile.Root.Attribute("xmlns").Value)).First().Add
			//using (XmlWriter writer = xFile.Descendants(XName.Get("body", xFile.Root.Attribute("xmlns").Value)).First().CreateWriter())
			//{

			//}
			Action action = new Action(() => webBrowser1.Document.Body.InnerHtml = content);
			webBrowser1.Invoke(action);
		}

		private void addFeedBttn_Click(object sender, EventArgs e)
		{
			AddFeedForm form = new AddFeedForm();
			var res = form.ShowDialog(this);
			//if(res == DialogResult.OK)
			//{
					
			//}
		}

		private void deleteFeedBttn_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				Feed activeFeed = listView1.SelectedItems[0].Tag as Feed;
				if (MessageBox.Show(this, "Are you sure you want to delete this feed?\r\n\"" + activeFeed.Name
					, "Confirm Delete", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
				{
					activeFeed.Group.Feeds.Remove(activeFeed);
					listView1.Items.Remove(listView1.SelectedItems[0]);
				}
			}
		}

		private void manualRefreshBttn_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				UpdateFeed(listView1.SelectedItems[0]);
			}
		}

		private void editFeedBttn_Click(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count > 0)
			{
				Feed activeFeed = listView1.SelectedItems[0].Tag as Feed;
				EditFeedForm form = new EditFeedForm(activeFeed);
				if (form.ShowDialog(this) == DialogResult.OK)
				{
					activeFeed = form._feed;
					MessageBox.Show("Changes saved.");
					BindListView();
				}
			}
		}
		private void manageGroupsBttn_Click(object sender, EventArgs e)
		{
			FeedGroup group = listView1.SelectedItems.Count > 0 ? (listView1.SelectedItems[0].Tag as Feed).Group : null;
			ManageGroupForm form = new ManageGroupForm(group);
			form.ShowDialog(this);
			BindListView();
		}
		//private void listView1_ClientSizeChanged(object sender, EventArgs e)
		//{
		//	listView1.Columns[0].Width = listView1.Width;
		//}

		private void listView1_DoubleClick(object sender, EventArgs e)
		{
			var item = listView1.SelectedItems[0];
			InjectHtmlContent((item.Tag as Feed).GetHtmlString());
			if (item.SubItems[2].Text == "unseen")
			{
				item.SubItems[2].Text = "seen";
				item.ImageKey = "rss";
				_notifiedItems.Remove(item);
				TryTurnOffNotified();
			}
		}
	}
}
