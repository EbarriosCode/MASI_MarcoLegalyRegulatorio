using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{
    public class LeyOrganizacion
    {
        [Key]
        public int LeyOrganizacionID { get; set; }        

        public int OrganizacionID { get; set; }
        public Organizacion Organizacion { get; set; }
        public int LeyID { get; set; }
        public Leyes Ley { get; set; }

        public ICollection<Verificacion> Verificaciones { get; set; }
    }
}
