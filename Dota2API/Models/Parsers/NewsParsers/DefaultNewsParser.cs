using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Syndication;
using System.Xml;
using System.Text;

namespace Dota2API.Models.Parsers
{
    public class DefaultNewsParser: BaseParser
    {
        public override object Parse(string url)
        {
            List<NewsModel> result = new List<NewsModel>();
            XmlReader reader = XmlReader.Create(url);
            XmlDocument doc = new XmlDocument();
            doc.Load(reader);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("content", doc.DocumentElement.GetNamespaceOfPrefix("content"));
            foreach (XmlNode n in doc.SelectNodes("/rss/channel/item"))
            {
                string link = HttpUtility.UrlDecode(n.SelectSingleNode("link").InnerText);
                result.Add(new NewsModel() {
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