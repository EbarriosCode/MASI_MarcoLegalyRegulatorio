using MASI_MarcoLegal.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Shared.Models
{
    public class Roles
    {
        [Key]
        public int RolId { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public String Rol { get; set; }
        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
