using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{
    public class Considerandos
    {
        [Key]
        public int ConsideranoID { get; set; }
        public string Descripcion { get; set; }
        public int LeyID { get; set; }               
        public Leyes Ley { get; set; }
    }
}
