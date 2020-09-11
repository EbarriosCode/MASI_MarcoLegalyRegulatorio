using System;
using System.Collections.Generic;
using System.Text;

namespace MASI_MarcoLegal.Shared.ViewModels
{
    public class TituloViewModel
    {
        public int TituloID { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public int LeyID { get; set; }
        public LeyesViewModel Ley { get; set; }
    }
}
