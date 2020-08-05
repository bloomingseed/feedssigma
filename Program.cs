using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FeedsSigma
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			try
			{
				//Config config = new Config();
				Config.LoadConfigurations();
				//MainForm mainForm = new MainForm(config);
				//mainForm.FormClosing += (sender, args) =>
				//{
				//	config = ((MainForm)sender).ExportConfigurations();
				//};
				//Application.Run(mainForm);
				Config.SaveConfigurations();
				//Feed myFeed = new RssFeed(0, File.ReadAllText("cnn.xml"));
			}
			catch(Exception err)
			{
				MessageBox.Show(err.Message + "\r\n\r\nPlease look for support at the FeedsSigma GitHub page."
					, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
