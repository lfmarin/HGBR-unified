using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ControlUsuarios.Models
{
    public class TokenBlacklist
    {
        [Key]
        public int IdToken { get; set; }
        [NotMapped]
        public string strToken { get; set; }
    }
}

