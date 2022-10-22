using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControlUsuarios.Models
{
    public partial class User
    {
        public int ID { get; set; }
        public string userName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public int IDDoctor { get; set; }

        //[JsonIgnore]
        //public bool? Canread { get; set; }

        //[JsonIgnore]
        //public bool? Canwrite { get; set; }

        [JsonIgnore]
        public int IdRole { get; set; }

        [JsonIgnore]
        public virtual Role IdRoleNavigation { get; set; }
    }
}