using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2API.Models.NewsParser
{
    public abstract class BaseParser : IParser
    {
        public abstract List<News> Parse(string url);
    }
}