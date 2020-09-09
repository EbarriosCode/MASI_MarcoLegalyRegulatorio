using System.ComponentModel.DataAnnotations;

namespace MASI_MarcoLegal.Shared.Models
{
    public class UsuarioLogin
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
