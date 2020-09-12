using MASI_MarcoLegal.Server.DataContext;
using MASI_MarcoLegal.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Services
{

    public interface IResultadosServices
    {
        Task<ResultadosViewModel> GetResultadoAsync(int VerificacionID);
        Task<IEnumerable<DetalleResultadoViewModel>> GetDetalleArticuloAsync(int IdVerificacion);
        Task<IEnumerable<DetalleResultadoViewModel>> GetDetalleIncisoAsync(int IdVerificacion);
        Task<IEnumerable<DetalleResultadoViewModel>> GetDetalleSubIncisoAsync(int IdVerificacion);
    }

    public class ResultadosServices : IResultadosServices
    {

        private readonly MASIContext _context;

        public ResultadosServices(MASIContext context) => this._context = context;

        public async Task<IEnumerable<DetalleResultadoViewModel>> GetDetalleArticuloAsync(int IdVerificacion)
        {
            var DetalleArticulos = new List<DetalleResultadoViewModel>();
            try
            {
                DetalleArticulos = await this._context.CumplimientosArticulos.Include(a => a.Articulo).Where(c => c.VerificacionID == IdVerificacion).Select(c => new DetalleResultadoViewModel()
                {
                    Descripcion = c.Articulo.Descripcion,
                    Cumple = c.Cumple
                }).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }



            return DetalleArticulos;
        }

        public async Task<IEnumerable<DetalleResultadoViewModel>> GetDetalleIncisoAsync(int IdVerificacion)
        {
            var DetalleArticulos = new List<DetalleResultadoViewModel>();
            try
            {
                DetalleArticulos = await this._context.CumplimientosIncisos.Include(a => a.Inciso).Where(c => c.VerificacionID == IdVerificacion).Select(c => new DetalleResultadoViewModel()
                {
                    Descripcion = c.Inciso.Descripcion,
                    Cumple = c.Cumple
                }).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return DetalleArticulos;
        }

        public async Task<IEnumerable<DetalleResultadoViewModel>> GetDetalleSubIncisoAsync(int IdVerificacion)
        {
            var DetalleArticulos = new List<DetalleResultadoViewModel>();
            try
            {
                DetalleArticulos = await this._context.CumplimientosSubIncisos.Include(a => a.SubInciso).Where(c => c.VerificacionID == IdVerificacion).Select(c => new DetalleResultadoViewModel()
                {
                    Descripcion = c.SubInciso.Descripcion,
                    Cumple = c.Cumple
                }).ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return DetalleArticulos;
        }

        public async Task<ResultadosViewModel> GetResultadoAsync(int VerificacionID)
        {
            ResultadosViewModel viewResultados = null;
            try
            {
                var Verificacion = await this._context.Verificaciones.Include(l => l.Ley).Include(o => o.Organizacion).FirstAsync(v => v.VerificacionID == VerificacionID);

                var LeyesViewModel = new LeyesViewModel
                {
                    LeyID = Verificacion.Ley.LeyID,
                    Descripcion = Verificacion.Ley.Descripcion
                };

                var OraganizacionView = new OrganizacionViewModel
                {
                    OrganizacionID = Verificacion.OrganizacionID,
                    Nombre = Verificacion.Organizacion.Nombre
                };

                var VerificacionViewModel = new VerificacionViewModel
                {
                    Ley = LeyesViewModel,
                    Organizacion = OraganizacionView,
                    FechaIngreso = Verificacion.FechaIngreso,
                    Usuario = Verificacion.Usuario,
                };


                Decimal articulosVerificables = await this._context.Articulos.Where(a => a.Verificable == true && a.Capitulo.Titulo.LeyID == Verificacion.LeyID).CountAsync();
                Decimal incisosVerificables = await this._context.Incisos.Where(i => i.Verificable == true && i.Articulo.Capitulo.Titulo.LeyID == Verificacion.LeyID).CountAsync();
                Decimal subIncisosVerificables = await this._context.SubIncisos.Where(si => si.Verificable == true && si.Inciso.Articulo.Capitulo.Titulo.LeyID == Verificacion.LeyID).CountAsync();

                Decimal TotalVerificableLey = articulosVerificables + incisosVerificables + subIncisosVerificables;

                Decimal cantidadArticulosCumplen = await this._context.CumplimientosArticulos.Where(ca => ca.Cumple == true && ca.Verificacion.LeyID == Verificacion.LeyID && ca.VerificacionID == Verificacion.VerificacionID).CountAsync();
                // cantidadArticulosNoCumplen = await this._context.CumplimientosArticulos.Where(ca => ca.Cumple == false && ca.Verificacion.LeyID == Verificacion.LeyID && ca.VerificacionID == Verificacion.VerificacionID).CountAsync();

                Decimal cantidadIncisosCumplen = await this._context.CumplimientosIncisos.Where(ci => ci.Cumple == true && ci.Verificacion.LeyID == Verificacion.LeyID && ci.VerificacionID == Verificacion.VerificacionID).CountAsync();
               // Decimal cantidadIncisosNoCumplen = await this._context.CumplimientosIncisos.Where(ci => ci.Cumple == false && ci.Verificacion.LeyID == Verificacion.LeyID && ci.VerificacionID == Verificacion.VerificacionID).CountAsync();

                Decimal cantidadSubIncisosCumplen = await this._context.CumplimientosSubIncisos.Where(cs => cs.Cumple == true && cs.Verificacion.LeyID == Verificacion.LeyID && cs.VerificacionID == Verificacion.VerificacionID).CountAsync();
                //Decimal cantidadSubIncisosNoCumplen = await this._context.CumplimientosSubIncisos.Where(cs => cs.Cumple == false && cs.Verificacion.LeyID == Verificacion.LeyID && cs.VerificacionID == Verificacion.VerificacionID).CountAsync();

                //Calculo de resultados
                Decimal porcentajeCumplimientoArticulo = (cantidadArticulosCumplen / articulosVerificables)*100m;
                Decimal porcentaJeNoCumplientoArticulos = 100m - porcentajeCumplimientoArticulo;

                Decimal porcentajeCumplimientoInciso = (cantidadIncisosCumplen / incisosVerificables) * 100m;
                Decimal porcentajeNoCumplimientoInciso = 100 - porcentajeCumplimientoInciso;

                Decimal porcentajeCumplimientoSubInciso = cantidadSubIncisosCumplen / subIncisosVerificables * 100;
                Decimal porcentajeNoCumplimientoSubInciso = 100 - porcentajeCumplimientoSubInciso;

                Decimal porcentajeCumplimientoTotal = (cantidadArticulosCumplen + cantidadIncisosCumplen + cantidadSubIncisosCumplen) / TotalVerificableLey * 100;
                Decimal porcentajeNoCumplimientoTotal = 100 - porcentajeCumplimientoTotal;

                viewResultados = new ResultadosViewModel
                {
                    Verificacion = VerificacionViewModel,
                    PorcentajeCumplimientoArticulo = porcentajeCumplimientoArticulo,
                    PorcentajeCumplimientoInciso = porcentajeCumplimientoInciso,
                    PorcentajeCumplimientoSubInciso = porcentajeCumplimientoSubInciso,
                    PorcentajeCumplimientoTotal = porcentajeCumplimientoTotal,
                    PorcentaJeNoCumplientoArticulos = porcentaJeNoCumplientoArticulos,
                    PorcentajeNoCumplimientoInciso = porcentajeNoCumplimientoInciso,
                    PorcentajeNoCumplimientoSubInciso = porcentajeNoCumplimientoSubInciso,
                    PorcentajeNoCumplimientoTotal = porcentajeNoCumplimientoTotal,
                    ArticulosVerificables = articulosVerificables,
                    IncisoVerificables = incisosVerificables,
                    SubIncisoVerificables = subIncisosVerificables,
                    TotalVerificables = TotalVerificableLey
                };

            }
            catch (Exception)
            {
                throw;
            }

            return viewResultados;
        }

    }
}
