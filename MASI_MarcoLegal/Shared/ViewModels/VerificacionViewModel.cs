using System;
using System.Collections.Generic;
using System.Text;

namespace MASI_MarcoLegal.Shared.ViewModels
{
    public class VerificacionViewModel
    {
        public int VerificacionID { get; set; }
        public int LeyID { get; set; }
        public LeyesViewModel Ley { get; set; }
        public int OrganizacionID { get; set; }
        public OrganizacionViewModel Organizacion { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Usuario { get; set; }
    }
}
