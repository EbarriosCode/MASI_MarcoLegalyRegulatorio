using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{
    public class Articulos
    {
        [Key]
        public int ArticuloID { get; set; }
        public string Descripcion { get; set; }
        public int CapituloID { get; set; }
        public Capitulos Capitulo { get; set; }

        public ICollection<Incisos> Incisos { get; set; }
    }
}
