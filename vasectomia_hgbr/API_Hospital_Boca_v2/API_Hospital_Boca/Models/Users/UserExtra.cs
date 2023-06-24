using System.ComponentModel.DataAnnotations.Schema;
namespace ControlUsuarios.Models
{
    public partial class User
    {
        [NotMapped]
        public string Token { get; set; }
    }
}

