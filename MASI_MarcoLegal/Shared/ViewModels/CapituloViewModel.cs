using System;
using System.Collections.Generic;
using System.Text;

namespace MASI_MarcoLegal.Shared.ViewModels
{
    public class CapituloViewModel
    {
        public int CapituloID { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public int TituloID { get; set; }
        public TituloViewModel Titulo { get; set; }
    }
}
