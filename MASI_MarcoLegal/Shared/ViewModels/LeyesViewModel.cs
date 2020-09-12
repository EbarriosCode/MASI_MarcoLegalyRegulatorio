using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MASI_MarcoLegal.Shared.ViewModels
{
    public class LeyesViewModel
    {
        public int LeyID { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public string Descripcion { get; set; }
    }
}
