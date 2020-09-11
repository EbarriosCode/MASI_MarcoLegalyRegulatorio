using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{
    public class Organizacion
    {
        [Key]
        public int OrganizacionID { get; set; }
        public string Nombre { get; set; }

        //public ICollection<LeyOrganizacion> LeyesOrganizaciones { get; set; }
        public ICollection<Verificacion> Verificaciones { get; set; }
    }
}
