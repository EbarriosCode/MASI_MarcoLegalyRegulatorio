using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MASI_MarcoLegal.Shared.ViewModels
{
    public class TituloViewModel
    {
        public int TituloID { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Detalle { get; set; }
        public int LeyID { get; set; }
        public LeyesViewModel Ley { get; set; }
    }
}
