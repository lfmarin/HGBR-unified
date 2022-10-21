using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControlUsuarios.Models
{
    public partial class User
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        [JsonIgnore]
        public bool? Canread { get; set; }

        [JsonIgnore]
        public bool? Canwrite { get; set; }

        [JsonIgnore]
        public int IdRole { get; set; }

        [JsonIgnore]
        public virtual Role IdRoleNavigation { get; set; }
    }
}