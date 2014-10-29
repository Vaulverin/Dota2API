using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2API.Models.Parsers
{
    public static class ParserFactory
    {
        public static BaseParser GetParser(ParserTypeEnum parserType)
        {
            BaseParser HParser = new DefaultNewsParser();
            switch (parserType)
            {
                case ParserTypeEnum.Dota2ru:
                    break;
            }
            return HParser;
        }
    }
}