using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using System.Net;

namespace FeedsSigma
{
	
	public static class Config
	{
		public static string AppPath { get; set; } = Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\FeedsSigma").FullName;
		public static int LastFeedId { get; set; }
		public static int LastGroupId { get; set; }
		public static List<FeedGroup> FeedGroups { get; set; }

		public static void SaveConfigurations()
		{
			using (FileStream file = new FileStream(AppPath + "\\config.ini", FileMode.Create))
			{
				using (XmlWriter writer = XmlWriter.Create(file))
				{
					writer.WriteStartDocument();
					writer.WriteWhitespace("\r\n");
					writer.WriteStartElement("root");
					writer.WriteWhitespace("\r\n"+new string(' ',3));

					writer.WriteStartElement("groups");
					writer.WriteWhitespace("\r\n" + new string(' ', 6));
					foreach (FeedGroup group in FeedGroups)
					{
						group.Serialize(writer);
					}
					writer.WriteWhitespace("\r\n" + new string(' ', 3));
					writer.WriteEndElement();
					writer.WriteWhitespace("\r\n");
					writer.WriteEndElement();
					writer.WriteEndDocument();
				}
			}
		}
		public static void LoadConfigurations()
		{
			FeedGroups = new List<FeedGroup>();
			try
			{
				if (!File.Exists(AppPath + "\\config.ini"))
				{
					//init feed group
					Feed devFeed = null;
					FeedGroup myFeeds = new FeedGroup(++LastGroupId)
					{
						Name = "My Feeds"
						//Weight = 1
					};
					//feeds path: ~\AppData\Local\FeedsSigma\feeds\{group id}\{feed id}.xml
					devFeed = Feed.CreateFromUrl("https://github.com/bloomingseed/novelssigma/commits/master.atom"
						, ++LastFeedId);
					myFeeds.Feeds.Add(devFeed);
					FeedGroups.Add(myFeeds);
				}
				else
				{
					XDocument xdoc = XDocument.Load(AppPath + "\\config.ini");
					foreach(XElement group in xdoc.Descendants("group"))
					{
						//this is fetching operation which doesn't increase any ids.
						LastGroupId = int.Parse(group.Element("id").Value);
						FeedGroup feedGroup = new FeedGroup(LastGroupId);
						feedGroup.Name = group.Element("name").Value;
						foreach (XElement feedElement in group.Descendants("feed"))
						{
							LastFeedId = int.Parse(feedElement.Element("id").Value);
							Feed feed = null;
							string checkedTime = feedElement.Element("lastChecked").Value;
							if (feedElement.Element("standard").Value == "rss")
								feed = new RssFeed(LastFeedId, File.ReadAllText(feedElement.Element("xml").Value), checkedTime);
							else
								feed = new AtomFeed(LastFeedId, File.ReadAllText(feedElement.Element("xml").Value), checkedTime);
							XElement updatePlanELement = feedElement.Element("updatePlan");
							if (updatePlanELement.HasElements)
							{
								TimeSpan time = TimeSpan.Parse((updatePlanELement.Element("time").Value));
								int freq = int.Parse(updatePlanELement.Element("frequency").Value);
								feed.UpdatePlan = new Tuple<TimeSpan, int>(time,freq);
							}
							feedGroup.Feeds.Add(feed);
						}
						FeedGroups.Add(feedGroup);
					}
				}
			}
			catch (Exception err) { throw err; }
		}
	}
}
