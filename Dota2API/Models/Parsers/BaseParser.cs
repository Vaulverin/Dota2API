using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dota2API.Models.Parsers
{
    public abstract class BaseParser : IParser
    {
        public abstract object Parse(string url);
    }
}