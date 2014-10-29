using System.ComponentModel.DataAnnotations;
using System;
using System.Runtime.Serialization;

namespace Dota2API.Models
{
    [DataContract]
    public class LeaguesModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [DataMember(Name = "leagueid")]
        
        public int LeagueId { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "description")]
        public string Description { get; set; }

        [DataMember(Name = "tournament_url")]
        public string TournamentUrl { get; set; }

        [DataMember(Name = "itemdef")]
        public int Itemdef { get; set; }

        public Languages Language { get; set; }
    }
}