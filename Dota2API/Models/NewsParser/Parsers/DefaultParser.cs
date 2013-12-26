using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Text;

namespace Dota2API.Models.NewsParser
{
    public class DefaultParser: BaseParser
    {
        public override List<News> Parse(string url)
        {
            List<News> result = new List<News>();
            XmlReader reader = XmlReader.Create(url);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("content", doc.DocumentElement.GetNamespaceOfPrefix("content"));
            foreach (XmlNode n in doc.SelectNodes("/rss/channel/item"))
            {
                string link = HttpUtility.UrlDecode(n.SelectSingleNode("link").InnerText);
                result.Add(new News() {
                    Title = n.SelectSingleNode("title").InnerText,
                    Content = n.SelectSingleNode("content:encoded", nsmgr).InnerText,
                    PublishDate = DateTime.Parse(n.SelectSingleNode("pubDate").InnerText),
                    Link = link
                });
                
            }
            return result;
        }
    }
}