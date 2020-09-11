using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Models
{
    [Table("CumplimientoArticulo")]
    public class CumplimientoArticulo
    {
        [Key]
        public int CumplimientoArticuloID { get; set; }        
        public int? VerificacionID { get; set; }
        public Verificacion Verificacion { get; set; }
        public bool Cumple { get; set; }
        public string Evidencia { get; set; }
        public int ArticuloID { get; set; }
        public Articulos Articulo { get; set; }
    }
}
