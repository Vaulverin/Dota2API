namespace Dota2API.Models
{
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Teams
    {
        [Required]
        public int team_id { get; set; }
        public string tag { get; set; }
        public int time_created { get; set; }
        public string rating { get; set; }
        public int logo { get; set; }
        public int logo_sponsor { get; set; }
        public string country_code { get; set; }
        public string url { get; set; }
        public int games_played_with_current_roster { get; set; }
        public string logo_sponsor { get; set; }
        public int admin_account_id { get; set; }
        //public int[] leagues { get; set; }
        //public int[] players { get; set; }
    }
}