using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Dota2API.Models.APIWorker
{
    [DataContract]
    public class APIResponseModel
    {
        [DataMember(Name="result")]
        public object Result { get; set; }

    }

    [DataContract]
    public class APILeaguesResponseMoldel
    {
        [DataMember(Name = "leagues")]
        public List<LeaguesModel> Leagues { get; set; } 
    }
}