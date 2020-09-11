using System;
using System.Collections.Generic;
using System.Text;

namespace MASI_MarcoLegal.Shared.ViewModels
{
    public class ItemsVerificablesViewModel
    {
        public List<ArticuloViewModel> Articulos { get; set; }
        public List<IncisoViewModel> Incisos { get; set; }
        public List<SubIncisoViewModel> SubIncisos { get; set; }
    }
}
