using System;
using System.Collections.Generic;
using System.Text;

namespace MASI_MarcoLegal.Shared.ViewModels
{
    public class ResultadosViewModel
    {
       public VerificacionViewModel Verificacion { set; get; }
       public Decimal PorcentajeCumplimientoArticulo { set; get; }
       public Decimal PorcentaJeNoCumplientoArticulos { set; get; }
       public Decimal PorcentajeCumplimientoInciso { set; get; }
       public Decimal PorcentajeNoCumplimientoInciso { set; get; }
       public Decimal PorcentajeCumplimientoSubInciso { set; get; }
       public Decimal PorcentajeNoCumplimientoSubInciso { set; get; }
       public Decimal PorcentajeCumplimientoTotal { set; get; }
       public Decimal PorcentajeNoCumplimientoTotal { set; get; }
       public Decimal ArticulosVerificables { set; get; }
       public Decimal IncisoVerificables { set; get; }
       public Decimal SubIncisoVerificables { set; get; }
       public Decimal TotalVerificables { set; get; }
        
    }
}
