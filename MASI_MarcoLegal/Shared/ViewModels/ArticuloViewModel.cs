using System;
using System.Collections.Generic;
using System.Text;

namespace MASI_MarcoLegal.Shared.ViewModels
{
    public class ArticuloViewModel
    {
        public int ArticuloID { get; set; }
        public string Descripcion { get; set; }
        public string Detalle { get; set; }
        public int CapituloID { get; set; }
        public CapituloViewModel Capitulo { get; set; }
        public bool Verificable { get; set; }
        public bool Cumple { get; set; }
        public string Evidencia { get; set; }        
    }
}
