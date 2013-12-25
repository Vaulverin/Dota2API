using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ServiceModel.Syndication;
using System.Xml;

namespace Dota2API.Models.NewsParser
{
    public class DefaultParser: BaseParser
    {
        public override List<News> Parse(string url)
        {
            List<News> result = new List<News>();
            XmlReader reader = XmlReader.Create(url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            foreach (SyndicationItem item in feed.Items)
            {
                result.Add(new News() { Title = item.Title.Text, Content = item.Summary.Text, PublishDate = item.PublishDate.DateTime });
            }
            return result;
        }
    }
}