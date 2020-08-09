﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using System.Net;

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
				Config.LoadConfigurations();
				MainForm mainForm = new MainForm();
				mainForm.FormClosing += (sender, args) => { Config.SaveConfigurations(); };
				Application.Run(mainForm);
				Config.SaveConfigurations();

				//TimeSpan t1 = TimeSpan.Parse("14:00:00"),
				//	t2 = TimeSpan.Parse("0:30:00");
				//Console.WriteLine(t1.ToString("h':'m':'s"));
				//Console.WriteLine(t2.ToString("h':'m':'s"));
				//Console.WriteLine(t2.ToString("h':'m':'s") == "0:30:00");
				//Console.WriteLine(t2.ToString("h':'m':'s") == "0:30:0");


			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message + "\r\n\r\nPlease look for support at the FeedsSigma GitHub page."
					, "An error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
