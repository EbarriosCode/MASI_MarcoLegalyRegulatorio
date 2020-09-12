using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MASI_MarcoLegal.Shared.ViewModels
{
    public class SubIncisoViewModel
    {
        public int SubIncisoID { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Detalle { get; set; }
        public int IncisoID { get; set; }
        public IncisoViewModel Inciso { get; set; }
        public bool Verificable { get; set; }
        public bool Cumple { get; set; }
        public string Evidencia { get; set; }
    }
}
