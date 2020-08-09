using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Net;

namespace FeedsSigma
{
	public static class Utilities
	{
		public static string GetStandard(string content)
		{
			XDocument xdoc = XDocument.Parse(content);
			if (xdoc.Root.Name == "rss")
				return "rss";
			else if (xdoc.Root.Name == "feed")
				return "atom";
			else return null;
		}
	}
}
