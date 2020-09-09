using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MASI_MarcoLegal.Shared.Models
{
    public class Usuarios
    {
        [Key]
        public int UsuarioID { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public String Usuario { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression(@"^.*(?=.{6,18})(?=.*\d)(?=.*[A-Za-z])(?=.*[@%&#]{0,}).*$", ErrorMessage = "La contraseña no cumple con los requisitoss")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public String Password { get; set; }

        [Required(ErrorMessage = "El campo contraseña es requerido")]
        public String Nombres { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public String Apellidos { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [EmailAddress]
        public String Correo { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        public String Puesto { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un rol")]
        public int RolId { get; set; }

        public Roles Rol { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "La contraseña de confirmación no es igual")]
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

    }
}
