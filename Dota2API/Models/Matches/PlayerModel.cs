using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Dota2API.Models.Matches
{
    [DataContract]
    public class PlayerModel
    {
        [DataMember(Name = "account_id")]
        public double AccountId { get; set; }

        [DataMember(Name = "player_slot")]
        public int PlayerSlot { get; set; }

        [DataMember(Name = "hero_id")]
        public int HeroId { get; set; }

        [DataMember(Name = "item_0")]
        public int Item_0 { get; set; }

        [DataMember(Name = "item_1")]
        public int Item_1 { get; set; }

        [DataMember(Name = "item_2")]
        public int Item_2 { get; set; }

        [DataMember(Name = "item_3")]
        public int Item_3 { get; set; }

        [DataMember(Name = "item_4")]
        public int Item_4 { get; set; }

        [DataMember(Name = "item_5")]
        public int Item_5 { get; set; }

        [DataMember(Name = "kills")]
        public int Kills { get; set; }

        [DataMember(Name = "deaths")]
        public int Deaths { get; set; }

        [DataMember(Name = "assists")]
        public int Assists { get; set; }

        [DataMember(Name = "leaver_status")]
        public int LeaverStatus { get; set; }

        [DataMember(Name = "gold")]
        public int Gold { get; set; }

        [DataMember(Name = "last_hits")]
        public int LastHits { get; set; }

        [DataMember(Name = "denies")]
        public int Denies { get; set; }

        [DataMember(Name = "gold_per_min")]
        public int GoldPerMin { get; set; }

        [DataMember(Name = "xp_per_min")]
        public int XpPerMin { get; set; }

        [DataMember(Name = "gold_spent")]
        public int GoldSpent { get; set; }

        [DataMember(Name = "hero_damage")]
        public int HeroDamage { get; set; }

        [DataMember(Name = "tower_damage")]
        public int TowerDamage { get; set; }

        [DataMember(Name = "hero_healing")]
        public int HeroHealing { get; set; }

        [DataMember(Name = "level")]
        public int Level { get; set; }

        [DataMember(Name = "ability_upgrades")]
        public AbilityModel AbilityUpgrades { get; set; }
    }
}