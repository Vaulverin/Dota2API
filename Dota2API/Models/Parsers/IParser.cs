using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2API.Models.Parsers
{
    interface IParser
    {
        object Parse(string url);
    }
}
