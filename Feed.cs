using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Net;

namespace FeedsSigma
{
	public abstract class Feed
	{
		public int Id { get; protected set; }
		public string Name { get; set; }
		public string Standard { get; protected set; }
		//public string Xml { get; protected set; }
		public string Link { get; protected set; }
		public string ImageUrl { get; protected set; }
		public Tuple<TimeSpan,int> UpdatePlan { get; set; }
		//public string LastChecked { get; protected set; }
		public DateTime LastChecked { get; protected set; }
		protected XDocument _xdoc { get; set; }
		public Dictionary<string, string> FeedDetails { get; protected set; }
		public Dictionary<int, Dictionary<string, string>> Items { get; protected set; }
		protected Feed(int id, string content, string checkedTime = null)
		{
			Id = id;
			LastChecked = checkedTime != null ? DateTime.Parse(checkedTime) : DateTime.Now;
			FeedDetails = new Dictionary<string, string>();
			Items = new Dictionary<int, Dictionary<string, string>>();
			_xdoc = XDocument.Parse(content);
			ExtractFeedInfo();

		}

		public FeedGroup Group { get; set; }

		public string GetHtmlString()
		{
			StringBuilder builder = new StringBuilder();
			XDocument templ = null, detailsTmpl = null, itemTmpl = null;
			try
			{
				//templ = XDocument.Load(new FileStream("web\\feedLayout.html", FileMode.Open));
				templ = XDocument.Parse(File.ReadAllText("web\\feedLayout.html"));
				detailsTmpl = XDocument.Parse(File.ReadAllText("web\\detailsLayout.html"));
				itemTmpl = XDocument.Parse(File.ReadAllText("web\\itemLayout.html"));

				XElement feedDetailsE = templ.Root.Element("div").Element("div"),
						feedItemsE = templ.Root.Element("div").Element("ul");



				if (ImageUrl != null && Uri.IsWellFormedUriString(ImageUrl, UriKind.Absolute))
				{
					using (XmlWriter anchorTmpl = XmlWriter.Create(new StringBuilder()))
					{
						anchorTmpl.WriteStartElement("a");
						anchorTmpl.WriteAttributeString("href", Link);
						anchorTmpl.WriteStartElement("img");
						anchorTmpl.WriteAttributeString("src", ImageUrl);
						anchorTmpl.WriteEndElement();
						anchorTmpl.WriteEndElement();
						builder.Append(anchorTmpl.ToString());
					}
				}


				////create anchor for this.Link
				//detailsTmpl.Root.Element("span").Value = "Link" + ':';
				//detailsTmpl.Root.Element("p").Value = "";
				//using (XmlWriter pWriter = detailsTmpl.Root.Element("p").CreateWriter())
				//{
				//	pWriter.WriteStartElement("a");
				//	pWriter.WriteAttributeString("href", Link);
				//	pWriter.WriteString(Link);
				//	pWriter.WriteEndElement();
				//}
				//builder.Append(detailsTmpl.ToString());

				foreach (KeyValuePair<string, string> attr in FeedDetails)
				{

					detailsTmpl.Root.Element("span").Value = attr.Key + ':';
					if (attr.Key == "Link")
					{
						detailsTmpl.Root.Element("p").Value = "";
						using (XmlWriter pWriter = detailsTmpl.Root.Element("p").CreateWriter())
						{
							pWriter.WriteStartElement("a");
							pWriter.WriteAttributeString("href", attr.Value);
							pWriter.WriteString(attr.Value);
							pWriter.WriteEndElement();
						}
					}
					else
					{
						detailsTmpl.Root.Element("p").Value = attr.Value;
					}

					builder.Append(detailsTmpl.ToString());
				}
				feedDetailsE.Value = "<h2>Feed details:</h2>"+builder.ToString()+"<hr /><h2>Articles:</h2>";
				builder.Clear();
				StringBuilder attrBuilder = new StringBuilder();
				// Generate <li>s
				foreach (var item in Items)
				{
					foreach (KeyValuePair<string, string> attr in item.Value)
					{
						//detailsTmpl.Root.Element("span").Value = attr.Key+':';
						//detailsTmpl.Root.Element("p").Value = attr.Value;
						//attrBuilder.Append(detailsTmpl.ToString());

						detailsTmpl.Root.Element("span").Value = attr.Key + ':';
						if (attr.Key == "Link")
						{
							detailsTmpl.Root.Element("p").Value = "";
							using (XmlWriter pWriter = detailsTmpl.Root.Element("p").CreateWriter())
							{
								pWriter.WriteStartElement("a");
								pWriter.WriteAttributeString("href", attr.Value);
								pWriter.WriteString(attr.Value);
								pWriter.WriteEndElement();
							}
						}
						else
						{
							detailsTmpl.Root.Element("p").Value = attr.Value;
						}

						attrBuilder.Append(WebUtility.HtmlDecode(detailsTmpl.ToString()));

					}
					itemTmpl.Root.Value = WebUtility.HtmlDecode(attrBuilder.ToString());
					//itemTmpl.
					attrBuilder.Clear();
					builder.Append(itemTmpl.ToString());
					builder.Append("<hr />");
				}
				feedItemsE.Value = WebUtility.HtmlDecode(builder.ToString());
				builder.Clear();
			}
			catch (Exception err) { throw err; }
			//return Utilities.UnescapeHtmlString(templ.ToString());
			return WebUtility.HtmlDecode(templ.ToString());
		}
		protected abstract void ExtractFeedInfo();
		public static Feed CreateFromUrl(string url, int feedId)
		{
			Feed feed = null;
			try
			{
				using (WebClient webClient = new WebClient())
				{
					string data = webClient.DownloadString(url);
					if (Utilities.GetStandard(data) == "rss")
						feed = new RssFeed(feedId, data);
					else
						feed = new AtomFeed(feedId, data);
				}
				return feed;
			}
			catch (Exception err) { throw err; }
		}
		public void Serialize(XmlWriter writer)
		{
			writer.WriteStartElement("feed");
			writer.WriteWhitespace("\r\n" + new string(' ', 15));
			writer.WriteElementString("id", Id.ToString());
			writer.WriteWhitespace("\r\n" + new string(' ', 15));
			writer.WriteElementString("name", Name);
			writer.WriteWhitespace("\r\n" + new string(' ', 15));
			writer.WriteElementString("standard", Standard);
			writer.WriteWhitespace("\r\n" + new string(' ', 15));
			writer.WriteElementString("link", Link);
			writer.WriteWhitespace("\r\n" + new string(' ', 15));
			writer.WriteElementString("imageUrl", ImageUrl != null ? ImageUrl : "");
			writer.WriteWhitespace("\r\n" + new string(' ', 15));
			//writer.WriteElementString("updatePlan", UpdatePlan.HasValue ? UpdatePlan.Value.ToString() : "");
			writer.WriteStartElement("updatePlan");
			writer.WriteWhitespace("\r\n" + new string(' ', 18));
			writer.WriteElementString("time", UpdatePlan.Item1.ToString());
			writer.WriteWhitespace("\r\n" + new string(' ', 18));
			writer.WriteElementString("frequency", UpdatePlan.Item2.ToString());
			writer.WriteWhitespace("\r\n" + new string(' ', 15));
			writer.WriteEndElement();
			writer.WriteWhitespace("\r\n" + new string(' ', 15));
			writer.WriteElementString("lastChecked", LastChecked != null ? LastChecked.ToString() : "");
			writer.WriteWhitespace("\r\n" + new string(' ', 15));
			writer.WriteStartElement("xml");
			string feedPath = Directory.CreateDirectory(Config.AppPath + $"\\{Config.FeedGroups.Find(group=>group.Feeds.Contains(this)).GetFolderName()}").FullName;
			feedPath += $"\\{this.GetFileName()}.xml";
			using (FileStream file = new FileStream(feedPath, FileMode.Create))
				_xdoc.Save(file);
			writer.WriteString(feedPath);
			writer.WriteEndElement();
			writer.WriteWhitespace("\r\n" + new string(' ', 12));
			writer.WriteEndElement();

			//output.Write(writer.ToString());
		}
		public string GetFileName() { return $"Feed{Id}"; }
		public override string ToString()
		{
			return $"#{this.Id.ToString()}.{this.Name}";
		}
	}
	public class FeedGroup
	{
		
		public int Id { get; protected set; }
		public string Name { get; set; }
		//public int Weight { get; set; }
		public FeedList Feeds { get; set; }

		public FeedGroup(int id)
		{
			Id = id;
			Feeds = new FeedList();
			this.Feeds.FeedAdded += AddFeedToGroup;
		}
		private void AddFeedToGroup(object sender, FeedList.FeedAddedEventArgs args)
		{
			args.AddedFeed.Group = this;
		}
		public void Serialize(XmlWriter writer)
		{
			writer.WriteStartElement("group");
			writer.WriteWhitespace("\r\n" + new string(' ', 9));
			writer.WriteElementString("id", Id.ToString());
			writer.WriteWhitespace("\r\n" + new string(' ', 9));
			writer.WriteElementString("name", Name);
			writer.WriteWhitespace("\r\n" + new string(' ', 9));
			//writer.WriteStartElement("weight");
			//writer.WriteString(Weight.ToString());
			//writer.WriteEndElement();
			writer.WriteStartElement("feeds");
			foreach (Feed feed in Feeds)
			{
				writer.WriteWhitespace("\r\n" + new string(' ', 12));
				feed.Serialize(writer);
				//writer.WriteString(feedWriter.GetStringBuilder().ToString());
			}
			writer.WriteWhitespace("\r\n" + new string(' ', 9));
			writer.WriteEndElement();
			writer.WriteWhitespace("\r\n" + new string(' ', 6));
			writer.WriteEndElement();

			//	output.Write(writer.ToString());
			//}
		}
		public string GetFolderName() { return $"Group{Id}"; }
		public override string ToString()
		{
			return $"#{Id}.{Name}";
		}
	}
	public class FeedList : List<Feed>
	{
		public class FeedAddedEventArgs : EventArgs
		{
			public Feed AddedFeed;
			public FeedAddedEventArgs(ref Feed feed)
			{
				AddedFeed = feed;
			}
		}
		public delegate void FeedAddedEventHandler(object sender, FeedAddedEventArgs args);
		public FeedAddedEventHandler FeedAdded;
		public new void Add(Feed feed)
		{
			base.Add(feed);
			FeedAdded?.Invoke(this, new FeedAddedEventArgs(ref feed));

		}
	}

	public class RssFeed : Feed
	{
		public RssFeed(int id, string content, string checkedTime = null) : base(id, content, checkedTime)
		{
		}
		protected override void ExtractFeedInfo()
		{

			XElement channel = _xdoc.Root.Element("channel");
			try
			{
				FeedDetails.Add("Title", channel.Element("title").Value);
				//Link = channel.Element("link").Value;
				FeedDetails.Add("Link", channel.Element("link").Value);
			}
			catch (Exception err) { throw err; }
			//init when it's hot
			Standard = "rss";
			Name = FeedDetails["Title"];
			Link = FeedDetails["Link"];

			XElement[] xes = new XElement[]
			{
				//channel.Element("author"),
				channel.Element("copyright"),
				channel.Element("description"),
				channel.Element("generator"),
				//channel.Element("image"),
				//channel.Element("lastBuildDate"),
			};
			//conditional assignment to feed properties
			XElement authorElement = channel.Element("author"),
				imageElement = channel.Element("image"),
				dateElement = channel.Element("lastBuildDate");
			if (authorElement != null)
			{
				if (authorElement.HasElements)
					FeedDetails.Add("Author", authorElement.Element("name").Value);
				else FeedDetails.Add("Author", authorElement.Value);
			}
			if (imageElement != null)
			{

				ImageUrl = imageElement.Element("url").Value;

			}
			if (dateElement != null)
			{
				FeedDetails.Add("LastBuildDate", DateTime.Parse(dateElement.Value).ToString());
			}
			foreach (var el in xes)
			{
				if (el != null)
				{
					string val = el.Value;
					if (el.Attribute("type") != null && el.Attribute("type").Value == "html")
						//val = Utilities.UnescapeHtmlString(val);
						val = WebUtility.HtmlDecode(val);
					FeedDetails.Add(
						char.ToUpper(el.Name.LocalName.ElementAt(0)) + el.Name.LocalName.Substring(1)
						, val
						);
				}
			}
			//init feed items
			var items = from item in channel.Elements("item")
						select item;

			foreach (var item in items)
			{
				xes = new XElement[]
				{
					item.Element("title"),
					item.Element("link"),
					item.Element("description"),
					item.Element("pubDate"),
				};
				var categories = item.Elements("category");
				authorElement = channel.Element("author");
				Dictionary<string, string> content = new Dictionary<string, string>();
				foreach (var el in xes)
				{
					if (el != null)
					{
						string val = el.Value;
						if (el.Attribute("type") != null && el.Attribute("type").Value == "html")
							//val = Utilities.UnescapeHtmlString(val);
							val = WebUtility.HtmlDecode(val);
						content.Add(
							char.ToUpper(el.Name.LocalName.ElementAt(0)) + el.Name.LocalName.Substring(1)
							, val
							);
					}
				}
				if (authorElement != null)
				{
					if (authorElement.HasElements)
						content.Add("Author", authorElement.Element("name").Value);
					else FeedDetails.Add("Author", authorElement.Value);
				}
				if (categories.Count() > 0)
				{
					content.Add(
							"Categories"
							, String.Join("; ", (from term in categories select term.Attribute("term").Value).ToArray())
							);
				}
				Items.Add(Items.Count + 1, content);
			}
		}
	}

	public class AtomFeed : Feed
	{

		public AtomFeed(int id, string content, string checkedTime = null) : base(id, content, checkedTime)
		{
		}
		protected override void ExtractFeedInfo()
		{

			XElement feed = _xdoc.Root;
			XNamespace xmlns = feed.Attribute("xmlns").Value;

			try
			{
				FeedDetails.Add("Title", feed.Element(XName.Get("title", xmlns.NamespaceName)).Value);
				//Link = feed.Element("link").Value;
				FeedDetails.Add("Link",
					(from linkElement in feed.Elements(XName.Get("link", xmlns.NamespaceName))
					 where linkElement.Attribute("rel").Value == "self"
					 select linkElement.Attribute("href").Value).First()
					);
			}
			catch (Exception err) { throw err; }
			//init when it's hot
			Standard = "atom";
			Name = FeedDetails["Title"];
			Link = FeedDetails["Link"];

			XElement[] xes = new XElement[]
			{
				//feed.Element("author"),
				feed.Element(XName.Get("rights", xmlns.NamespaceName)),
				feed.Element(XName.Get("subtitle", xmlns.NamespaceName)),
				feed.Element(XName.Get("generator", xmlns.NamespaceName)),
				feed.Element(XName.Get("id", xmlns.NamespaceName)),
				//feed.Element(XName.Get("updated", xmlns.NamespaceName)),
			};
			//conditional assignment to feed properties
			XElement authorElement = feed.Element(XName.Get("author", xmlns.NamespaceName)),
				logoElement = feed.Element(XName.Get("logo", xmlns.NamespaceName)),
				dateElement = feed.Element(XName.Get("updated", xmlns.NamespaceName));

			if (authorElement != null)
			{
				if (authorElement.HasElements)
					FeedDetails.Add("Author", authorElement.Element(XName.Get("name", xmlns.NamespaceName)).Value);
				else FeedDetails.Add("Author", authorElement.Value);
			}
			if (logoElement != null)
			{

				ImageUrl = logoElement.Element(XName.Get("url", xmlns.NamespaceName)).Value;

			}
			if (dateElement != null)
			{
				FeedDetails.Add("Updated", DateTime.Parse(dateElement.Value).ToString());
			}
			foreach (var el in xes)
			{
				if (el != null)
				{
					string val = el.Value;
					if (el.Attribute("type") != null && el.Attribute("type").Value == "html")
						//val = Utilities.UnescapeHtmlString(val);
						val = WebUtility.HtmlDecode(val);
					FeedDetails.Add(
						char.ToUpper(el.Name.LocalName.ElementAt(0)) + el.Name.LocalName.Substring(1)
						, val
						);
				}
			}
			//
			//init feed items
			var items = from item in feed.Elements(XName.Get("entry", xmlns.NamespaceName))
						select item;

			foreach (var item in items)
			{
				xes = new XElement[]
				{
					item.Element(XName.Get("title", xmlns.NamespaceName)),
					item.Element(XName.Get("sumarry", xmlns.NamespaceName)),
					item.Element(XName.Get("content", xmlns.NamespaceName)),
					item.Element(XName.Get("updated", xmlns.NamespaceName)),
				};
				var categories = item.Elements(XName.Get("category", xmlns.NamespaceName));
				authorElement = feed.Element(XName.Get("author", xmlns.NamespaceName));
				XElement linkElm = (from linkE in feed.Elements(XName.Get("link", xmlns.NamespaceName))
									where linkE.Attribute("rel").Value == "alternate"
									select linkE).FirstOrDefault();
				Dictionary<string, string> content = new Dictionary<string, string>();
				foreach (var el in xes)
				{
					if (el != null)
					{
						string val = el.Value;
						if (el.Name.LocalName == "updated")
							val = DateTime.Parse(val).ToString();
						else if (el.Attribute("type") != null && el.Attribute("type").Value == "html")
							//val = Utilities.UnescapeHtmlString(val);
							val = WebUtility.HtmlDecode(val);
						content.Add(
							char.ToUpper(el.Name.LocalName.ElementAt(0)) + el.Name.LocalName.Substring(1)
							, val
							);
					}
				}
				//
				// manually add some values
				if (authorElement != null)
				{
					if (authorElement.HasElements)
						content.Add("Author", authorElement.Element(XName.Get("name", xmlns.NamespaceName)).Value);
					else FeedDetails.Add("Author", authorElement.Value);
				}
				if (categories.Count() > 0)
				{
					content.Add(
							"Categories"
							, String.Join("; ", (from term in categories select term.Attribute("term").Value).ToArray())
							);
				}
				if (linkElm != null)
				{
					content.Add("Link", linkElm.Attribute("href").Value);
				}
				Items.Add(Items.Count, content);
			}
		}
	}
}
