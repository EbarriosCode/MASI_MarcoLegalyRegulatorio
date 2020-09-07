using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{
    public class Capitulos
    {
        [Key]
        public int CapituloID { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public int TituloID { get; set; }
        public Titulos Titulo { get; set; }

        public ICollection<Articulos> Articulos { get; set; }
    }
}
