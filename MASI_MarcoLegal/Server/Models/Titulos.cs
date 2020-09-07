using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{
    public class Titulos
    {
        [Key]
        public int TituloID { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public int LeyID { get; set; }
        public Leyes Ley { get; set; }

        public ICollection<Capitulos> Capitulos { get; set; }
    }
}
