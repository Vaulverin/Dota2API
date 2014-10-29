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
    public class APILeaguesResponseModel
    {
        [DataMember(Name = "leagues")]
        public List<LeaguesModel> Leagues { get; set; } 
    }
    [DataContract]
    public class APIMatchesHistoryResponseModel
    {
        [DataMember(Name = "status")]
        public int Status { get; set; }

        [DataMember(Name = "num_results")]
        public int NumResults { get; set; }

        [DataMember(Name = "total_results")]
        public int TotalResults { get; set; }

        [DataMember(Name = "results_remaining")]
        public int ResultsRemaining { get; set; }

        [DataMember(Name = "matches")]
        public List<Matches.MatchesModel> Matches { get; set; }
    }
}