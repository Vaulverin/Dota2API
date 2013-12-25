using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dota2API.Models.NewsParser
{
    interface IParser
    {
        List<News> Parse(string url);
    }
}
