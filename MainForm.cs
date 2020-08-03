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
		public MainForm()
		{
			InitializeComponent();
			Uri uri = new Uri(@"file:///" + Directory.GetCurrentDirectory().Replace("\\", "/") + @"/web/_layout.html");
			//webBrowser1.Navigate("https://www.google.com");
			webBrowser1.Navigate(uri.AbsoluteUri);
			webBrowser1.DocumentCompleted += (sender, args) => Task.Run(async ()=> await InjectHtmlContent("web/welcome.html"));

		}

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

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			TugIntoSystemTray();
			e.Cancel = true;

		}
		private void label1_MouseDown(object sender, MouseEventArgs e)
		{
			lastLocation = e.Location;
		}

		private void label1_MouseMove(object sender, MouseEventArgs e)
		{
			if(MouseButtons.Left == e.Button)
				this.DesktopLocation = new Point(MousePosition.X - lastLocation.X, MousePosition.Y - lastLocation.Y);
		}

		private void toolStripButton1_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void toolStripButton4_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private async Task InjectHtmlContent(string path)
		{
			string contnt = null;
			using (FileStream fileStream = new FileStream(path, FileMode.Open))
				using (StreamReader streamReader = new StreamReader(fileStream))
					contnt = await streamReader.ReadToEndAsync();
			Action action = new Action(() => webBrowser1.Document.Body.InnerHtml = contnt);
			webBrowser1.Invoke(action);
		}
	}
}
