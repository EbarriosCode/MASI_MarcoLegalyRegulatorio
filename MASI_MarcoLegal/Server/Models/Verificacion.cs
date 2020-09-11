using MASI_MarcoLegal.Client.Pages.MarcoLegal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{
    [Table("Verificacion")]
    public class Verificacion
    {
        public int VerificacionID { get; set; }
        public int LeyID { get; set; }
        public Leyes Ley { get; set; }
        public int OrganizacionID { get; set; }
        public Organizacion Organizacion { get; set; }

        public DateTime FechaIngreso { get; set; }
        public string Usuario { get; set; }
    }
}
