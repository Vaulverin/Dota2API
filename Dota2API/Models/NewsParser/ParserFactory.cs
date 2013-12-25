using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2API.Models.NewsParser
{
    public static class ParserFactory
    {
        public static BaseParser GetParser(string type)
        {
            BaseParser HParser = new DefaultParser();
            switch (type)
            { 
                case "Dota2ru":
                    break;
            }
            return HParser;
        }
    }
}