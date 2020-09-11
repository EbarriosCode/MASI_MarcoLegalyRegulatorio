using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{
    public class SubIncisos
    {
        [Key]
        public int SubIncisoID { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public int IncisoID { get; set; }
        public Incisos Inciso { get; set; }
        public bool Verificable { get; set; }

        public ICollection<CumplimientoSubInciso> CumplimientoSubIncisos { get; set; }
    }
}
