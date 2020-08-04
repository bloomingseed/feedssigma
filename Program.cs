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
			//Application.Run(new MainForm());
			RssFeed myFeed = null;
			using (FileStream file = new FileStream("cnn.xml", FileMode.Open))
				myFeed = new RssFeed(file);
			//Application.Run(new MainForm());
			string htmlString = myFeed.GetHtmlString();
		}
	}
}
