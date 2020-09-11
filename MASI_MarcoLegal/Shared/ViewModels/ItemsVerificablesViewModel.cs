using System;
using System.Collections.Generic;
using System.Text;

namespace MASI_MarcoLegal.Shared.ViewModels
{
    public class ItemsVerificablesViewModel
    {
        public int LeyID { get; set; }
        public int OrganizacionID { get; set; }
        public List<ArticuloViewModel> Articulos { get; set; }
        public List<IncisoViewModel> Incisos { get; set; }
        public List<SubIncisoViewModel> SubIncisos { get; set; }
        public string User { get; set; }
    }
}
