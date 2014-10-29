using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace Dota2API.Models.Matches
{
    [DataContract]
    public class AbilityModel
    {
        [DataMember(Name = "ability")]
        public int Ability { get; set; }
        [DataMember(Name = "time")]
        public int Time { get; set; }
        [DataMember(Name = "level")]
        public int Level { get; set; }
    }
}