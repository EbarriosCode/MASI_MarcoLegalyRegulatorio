using System;
using System.Collections.Generic;
using System.Text;

namespace MASI_MarcoLegal.Shared.ViewModels
{
    public class LeyOrganizacionViewModel
    {
        public int OrganizacionID { get; set; }
        public OrganizacionViewModel Organizacion { get; set; }
        public int LeyID { get; set; }
        public LeyesViewModel Ley { get; set; }
    }
}
