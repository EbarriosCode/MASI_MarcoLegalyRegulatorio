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
        public bool Verificable { get; set; }

        public ICollection<SubIncisos> SubIncisos { get; set; }
        public ICollection<CumplimientoInciso> CumplimientoIncisos { get; set; }
    }
}
