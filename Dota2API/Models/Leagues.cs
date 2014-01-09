namespace Dota2API.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Leagues
    {
        [Required]
        public int leagueid { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string tournament_url { get; set; }
        public int itemdef { get; set; }
    }
}