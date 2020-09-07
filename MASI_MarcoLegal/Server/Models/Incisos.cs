using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{
    public class Incisos
    {
        [Key]
        public int IncisoID { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public int ArticuloID { get; set; }
        public Articulos Articulo { get; set; }

        public ICollection<Cumplimientos> Cumplimientos { get; set; }
    }
}
