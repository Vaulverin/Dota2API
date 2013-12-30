using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Dota2API.Controllers
{
    
    public class QuerySenderController : ApiController
    {

        public class UrlFormObject
        {
            public string Url{ get; set; }
        }

        public string Post(UrlFormObject Form)
        {
            var json = new WebClient().DownloadString(Form.Url);
            return json;
        }

        
    }
}
