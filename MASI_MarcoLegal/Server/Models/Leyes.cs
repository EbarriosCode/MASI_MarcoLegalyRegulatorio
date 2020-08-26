using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{   
    public class Leyes
    {
        [Key]
        public int LeyID { get; set; }
        public string Descripcion { get; set; }

        public ICollection<Considerandos> Considerandos { get; set; }
        public ICollection<Titulos> Titulos { get; set; }
    }
}
