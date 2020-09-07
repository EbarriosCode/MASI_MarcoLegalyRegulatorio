using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{
    public class Cumplimientos
    {
        [Key]
        public int CumplimientoID { get; set; }
        public int IncisoID { get; set; }
        public Incisos Inciso { get; set; }
        public bool Cumple { get; set; }
        public string Evidencia { get; set; }
    }
}
