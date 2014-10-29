using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Dota2API.Models.Matches
{
    [DataContract]
    public class MatchesModel
    {
        [DataMember(Name = "series_id")]
        public double SeriesId { get; set; }

        [DataMember(Name = "series_type")]
        public int SeriesType { get; set; }

        [DataMember(Name = "radiant_win")]
        public bool RadiantWin { get; set; }

        [DataMember(Name = "duration")]
        public int Duration { get; set; }

        [DataMember(Name = "start_time")]
        public double StartTime { get; set; }

        [DataMember(Name = "match_id")]
        public double MatchId { get; set; }

        [DataMember(Name = "match_seq_num")]
        public double MatchSeqNum { get; set; }

        [DataMember(Name = "tower_status_radiant")]
        public int TowerStatusRadiant { get; set; }

        [DataMember(Name = "tower_status_dire")]
        public int TowerStatusDire { get; set; }

        [DataMember(Name = "barracks_status_radiant")]
        public int BarracksStatusRadiant { get; set; }

        [DataMember(Name = "barracks_status_dire")]
        public int BarracksStatusDire { get; set; }

        [DataMember(Name = "cluster")]
        public int cluster { get; set; }

        [DataMember(Name = "first_blood_time")]
        public int FirstBloodTime { get; set; }

        [DataMember(Name = "lobby_type")]
        public int LobbyType { get; set; }

        [DataMember(Name = "human_players")]
        public int HumanPlayers { get; set; }

        [DataMember(Name = "leagueid")]
        public int LeagueId { get; set; }

        [DataMember(Name = "positive_votes")]
        public int PositiveVotes { get; set; }

        [DataMember(Name = "negative_votes")]
        public int NegativeVotes { get; set; }

        [DataMember(Name = "game_mode")]
        public int GameMode { get; set; }

        [DataMember(Name = "radiant_captain")]
        public double RadiantCaptain { get; set; }

        [DataMember(Name = "dire_captain")]
        public double DireCaptain { get; set; }

        [DataMember(Name = "players")]
        public PlayerModel Players { get; set; }
    }
}