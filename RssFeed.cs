using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.IO;

namespace FeedsSigma
{
	//public abstract class Feed<T> where T:FeedItem
	public abstract class Feed
	{
		public string Name { get; set; }
		//public string Title { get; protected set; }	//x
		public string Standard { get; protected set; }
		public string Xml { get; protected set; }
		public Dictionary<string, string> FeedDetails { get; protected set; }
		//public List<T> Items { get; protected set; }
		public Dictionary<int, Dictionary<string, string>> Items { get; protected set; }
		//public string Link { get; protected set; }	//x
		protected Feed() 
		{
			FeedDetails = new Dictionary<string, string>();
			//Items = new List<T>(); 
			Items = new Dictionary<int, Dictionary<string, string>>();
		}

		public FeedGroup Group { get; protected set; }
		public static string GetStandard(XDocument xdoc)
		{
			if (xdoc.Root.Name == "rss")
				return "rss";
			else if (xdoc.Root.Name == "feed")
				return "atom";
			else return null;
		}
		public static string UnescapeHtmlString(string htmlString)
		{
			return htmlString.Replace("&quot", "\"")
				.Replace("&amp;", "&")
				.Replace("&apos;", "'")
				.Replace("&lt;", "<")
				.Replace("&gt;", ">");
		}
		public string GetHtmlString()
		{
			StringBuilder builder = new StringBuilder();
			XDocument templ = null, detailsTmpl = null, itemTmpl = null;
			try
			{
				templ = XDocument.Load(new FileStream("web\\feedLayout.html", FileMode.Open));
				detailsTmpl = XDocument.Load(new FileStream("web\\detailsLayout.html", FileMode.Open));
				itemTmpl = XDocument.Load(new FileStream("web\\itemLayout.html", FileMode.Open));
			
				XElement feedDetailsE = templ.Root.Element("div").Element("div"),
						feedItemsE = templ.Root.Element("div").Element("ul");

				foreach(KeyValuePair<string,string> attr in FeedDetails)
				{
					detailsTmpl.Root.Element("span").Value = attr.Key+':';
					detailsTmpl.Root.Element("p").Value = attr.Value;
					builder.Append(detailsTmpl.ToString());
					
				}
				feedDetailsE.Value = builder.ToString();
				builder.Clear();
				StringBuilder attrBuilder = new StringBuilder();
				foreach (var item in Items)
				{
					foreach(KeyValuePair<string,string> attr in item.Value)
					{
						detailsTmpl.Root.Element("span").Value = attr.Key+':';
						detailsTmpl.Root.Element("p").Value = attr.Value;
						attrBuilder.Append(detailsTmpl.ToString());
					
					}
					itemTmpl.Root.Value = attrBuilder.ToString();
					//itemTmpl.
					attrBuilder.Clear();
					builder.Append(itemTmpl.ToString());
				}
				feedItemsE.Value = builder.ToString();
				builder.Clear();
			}
			catch(Exception err) { throw err; }
			return Feed.UnescapeHtmlString(templ.ToString());
		}
	}
	//public abstract class FeedItem
	//{
	//	public string Title { get; protected set; }
	//	public string Link { get; protected set; }
	//	public string[] Categories { get; protected set; }
	//	protected FeedItem(string title, string link) 
	//	{
	//		Title = title;
	//		Link = Uri.IsWellFormedUriString(link, UriKind.Absolute)?link:null;
	//		if (Link == null) throw new Exception("Invalid URL");
	//	}
	//	public virtual string GetHtmlString()
	//	{

	//	}
	//}
	public class FeedGroup
	{
		public string Name { get; set; }
		public int Index { get; }
		//public List<Feed<FeedItem>> Feeds { get; set; }
	}
	//public class RssFeed : Feed<RssFeedItem>
	public class RssFeed:Feed
	{
		//Reduced some elements; total: 10 properties - 10 elements
		//public string Author { get; protected set; }
		//public string Copyright { get; protected set; }
		//public string Description { get; protected set; }
		//public string Generator { get; protected set; }
		//public string ImageUrl { get; protected set; }
		//public string LastBuildDate { get; protected set; }
		
		//public List
		protected XElement _xdoc { get; set; }

		public RssFeed(Stream content)
		{
			_xdoc = XElement.Load(content).Elements().First();
			using (StreamReader reader = new StreamReader(content))
				Xml = reader.ReadToEnd();
			Standard = "rss";
			//Items = new List<RssFeedItem>();
			ExtractFeedInfo();
			//TODO: Save this feed to database asynchronously
			//..
		}
		private void ExtractFeedInfo()
		{
			try
			{
				FeedDetails.Add("Title", _xdoc.Element("title").Value);
				FeedDetails.Add("Link", _xdoc.Element("link").Value);
			}
			catch(Exception err) { throw new Exception("Invalid feed format"); }
			XElement[] xes = new XElement[]
			{
				//_xdoc.Element("author"),
				_xdoc.Element("copyright"),
				_xdoc.Element("description"),
				_xdoc.Element("generator"),
				_xdoc.Element("image"),
				_xdoc.Element("lastBuildDate"),
			};
			//conditional assignment to feed properties
			XElement authorElement = _xdoc.Element("author");
			if (authorElement != null)
			{
				if (authorElement.HasElements)
					FeedDetails.Add("Author", authorElement.Element("name").Value);
				else FeedDetails.Add("Author", authorElement.Value);
			}
			foreach (var el in xes)
			{
				if (el != null)
				{
					FeedDetails.Add(
						char.ToUpper(el.Name.LocalName.ElementAt(0)) + el.Name.LocalName.Substring(1)
						, el.Value);
					
				}
			}
			//xes[c] != null ? xes[c].Value : null;++c;
			//FeedDetails.Add("Copyright = xes[c] != null ? xes[c].Value : null;++c;
			//FeedDetails.Add("Description = xes[c] != null ? xes[c].Value : null;++c;
			//FeedDetails.Add("Generator = xes[c] != null ? xes[c].Value : null;++c;
			//FeedDetails.Add("ImageUrl = xes[c] != null ? xes[c].Element("url").Value : null;++c;
			//FeedDetails.Add("LastBuildDate = xes[c] != null ? xes[c].Value : null;

			//init feed items
			var items = from item in _xdoc.Elements("item")
						select item;
			
			foreach (var item in items)
			{
				xes = new XElement[]
				{
					item.Element("title"),
					item.Element("link"),
					//item.Element("author"),
					item.Element("description"),
					item.Element("pubDate"),
				};
				var categories = item.Elements("category");
				authorElement = _xdoc.Element("author");
				Dictionary<string, string> content = new Dictionary<string, string>();
				foreach (var el in xes)
				{
					if (el != null)
					{
						content.Add(
							char.ToUpper(el.Name.LocalName.ElementAt(0)) + el.Name.LocalName.Substring(1)
							, el.Value
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
				//Items.Add(new RssFeedItem(
				//	xes[c++] != null ? xes[c - 1].Value : "No title.",
				//	xes[c++] != null ? xes[c - 1].Value : "No article URL.",
				//	xes[c++] != null ? xes[c - 1].Value : "No article author.",
				//	xes[c++] != null ? xes[c - 1].Value : "No article description.",
				//	xes[c++] != null ? xes[c - 1].Value : "No publish date.",
				//	categories.Count() > 0 ?
				//	(from term in categories select term.Attribute("term").Value).ToArray()
				//	: null
				//));
			}
		}
		//public string ToHtmlString()
		//{
		//	XElement feedTemplate = null, iTemplate = null;
		//	using (FileStream file = new FileStream("feedLayout.xml", FileMode.Open))
		//		feedTemplate = XElement.Load(file);
		//	using (FileStream file = new FileStream("itemLayout.xml", FileMode.Open))
		//		iTemplate = XElement.Load(file);
		//	XElement[] elms = (from elm in feedTemplate.Descendants("p") select elm).ToArray();
		//	int c = 0;
		//	elms[c++].Value += this.Title;
		//	elms[c++].Value += this.Description;
		//	elms[c++].Value += this.Url;
		//	XElement itemsEntry = feedTemplate.Descendants("ul").First();
		//	XElement tmp = null;
		//	XElement[] tmpList = null;
		//	foreach (FeedItem item in Items)
		//	{
		//		tmp = new XElement(iTemplate);
		//		tmpList = (from p in tmp.Descendants("p") select p).ToArray();
		//		c = 0;
		//		tmpList[c++].Value += item.Title;
		//		tmpList[c++].Value += item.Description;
		//		tmpList[c++].Value += item.PublishDate;
		//		tmpList[c++].Value += item.Url;
		//		itemsEntry.Value += (string)tmp;
		//	}
		//	return (string)feedTemplate;
		//}
	}
	//public class RssFeedItem : FeedItem
	//{
	//	public string Author { get; protected set; }
	//	public string Description { get; protected set; }
	//	public string PublishDate { get; protected set; }	//pubDate
	//	public RssFeedItem(
	//		string title, string link, string author, 
	//		string description, string pubDate, string[] categories = null
	//		):base(title,link)
	//	{
	//		Author = author;
	//		Description = description;
	//		PublishDate = pubDate;
	//		Categories = categories;
	//	}
	//	public override string GetHtmlString()
	//	{
	//		//TODO: implement full
	//		//string s = base.GetHtmlString();
	//	}


	//}
}
