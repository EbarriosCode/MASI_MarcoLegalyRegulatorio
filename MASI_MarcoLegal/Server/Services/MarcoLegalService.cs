﻿using MASI_MarcoLegal.Server.DataContext;
using MASI_MarcoLegal.Server.Models;
using MASI_MarcoLegal.Shared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Services
{
    public interface IMarcolegalService
    {
        Task<IEnumerable<Verificacion>> GetLeyesOrganizacionesAsync();
        Task<IEnumerable<Organizacion>> GetOrganizacionesAsync();
        Task<IEnumerable<Leyes>> GetLeyesAsync();
        Task<IEnumerable<Titulos>> GetTitulosAsync();
        Task<IEnumerable<Capitulos>> GetCapitulosAsync();
        Task<IEnumerable<Articulos>> GetArticulosAsync();
        Task<IEnumerable<Articulos>> GetArticulosNoVerificablesAsync();
        Task<IEnumerable<Incisos>> GetIncisosAsync();
        Task<IEnumerable<Incisos>> GetIncisosNoVerificablesAsync();
        Task<IEnumerable<SubIncisos>> GetSubIncisosAsync();
        Task<ItemsVerificablesViewModel> GetItemsVerificablesAsync(int LeyID);
        Task<bool> CreateVerificacionAsync(ItemsVerificablesViewModel model);
        Task<bool> CreateOrganizacionAsync(OrganizacionViewModel model);
        Task<bool> CreateLeyAsync(LeyesViewModel model);
        Task<bool> CreateTituloAsync(TituloViewModel model);
        Task<bool> CreateCapituloAsync(CapituloViewModel model);
        Task<bool> CreateArticuloAsync(ArticuloViewModel model);
        Task<bool> CreateIncisoAsync(IncisoViewModel model);
        Task<bool> CreateSubIncisoAsync(SubIncisoViewModel model);
        Task<IEnumerable<Verificacion>> GetVerificacionesAsync();
    }
    public class MarcoLegalService : IMarcolegalService
    {
        private readonly MASIContext _context;

        public MarcoLegalService(MASIContext context) => this._context = context;

        public async Task<IEnumerable<Verificacion>> GetLeyesOrganizacionesAsync()
        {
            var ultimosResultados = new List<Verificacion>();

            try
            {
                ultimosResultados = await this._context.Verificaciones
                                                        .Include(v => v.Ley)
                                                        .Include(v => v.Organizacion)
                                                        .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return ultimosResultados;
        }

        public async Task<IEnumerable<Organizacion>> GetOrganizacionesAsync()
        {
            var organizacions = new List<Organizacion>();

            try
            {
                organizacions = await this._context
                                        .Organizaciones
                                        .ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return organizacions;
        }

        public async Task<IEnumerable<Leyes>> GetLeyesAsync()
        {
            var leyes = new List<Leyes>();

            try
            {
                leyes = await this._context
                                        .Leyes
                                        //.Include(l => l.Considerandos)
                                        //.Include(l => l.Titulos)
                                        //    .ThenInclude(l => l.Capitulos)
                                        //        .ThenInclude(l => l.Articulos)
                                        //            .ThenInclude(l => l.Incisos)
                                        //                .ThenInclude(l => l.SubIncisos)
                                        .ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return leyes;
        }

        public async Task<IEnumerable<Titulos>> GetTitulosAsync()
        {
            var titulos = new List<Titulos>();

            try
            {
                titulos = await this._context
                                        .Titulos
                                        .Include(t => t.Ley)
                                        .ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return titulos;
        }

        public async Task<IEnumerable<Capitulos>> GetCapitulosAsync()
        {
            var capitulos = new List<Capitulos>();

            try
            {
                capitulos = await this._context
                                        .Capitulos
                                        .Include(c => c.Titulo)
                                            .ThenInclude(l => l.Ley)
                                        .OrderBy(c => c.CapituloID)
                                        .ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return capitulos;
        }

        public async Task<IEnumerable<Articulos>> GetArticulosAsync()
        {
            var articulos = new List<Articulos>();

            try
            {
                articulos = await this._context
                                        .Articulos
                                        .Include(a => a.Capitulo)
                                            .ThenInclude(c => c.Titulo)
                                                .ThenInclude(l => l.Ley)
                                        .OrderBy(a => a.ArticuloID)
                                        .ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return articulos;
        }

        public async Task<IEnumerable<Articulos>> GetArticulosNoVerificablesAsync()
        {
            var articulos = new List<Articulos>();

            try
            {
                articulos = await this._context
                                        .Articulos
                                        .Include(a => a.Capitulo)
                                            .ThenInclude(c => c.Titulo)
                                                .ThenInclude(l => l.Ley)
                                        .Where(a => a.Verificable == false)
                                        .OrderBy(a => a.ArticuloID)
                                        .ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return articulos;
        }

        public async Task<IEnumerable<Incisos>> GetIncisosAsync()
        {
            var incisos = new List<Incisos>();

            try
            {
                incisos = await this._context
                                        .Incisos
                                        .Include(i => i.Articulo)                                            
                                            .ThenInclude(a => a.Capitulo)
                                                .ThenInclude(c => c.Titulo)
                                                    .ThenInclude(l => l.Ley)
                                        .OrderBy(a => a.IncisoID)
                                        .ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return incisos;
        }

        public async Task<IEnumerable<Incisos>> GetIncisosNoVerificablesAsync()
        {
            var incisos = new List<Incisos>();

            try
            {
                incisos = await this._context
                                        .Incisos
                                        .Include(i => i.Articulo)
                                            .ThenInclude(a => a.Capitulo)
                                                .ThenInclude(c => c.Titulo)
                                                    .ThenInclude(l => l.Ley)
                                        .Where(i => i.Verificable == false)
                                        .OrderBy(a => a.IncisoID)
                                        .ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return incisos;
        }

        public async Task<IEnumerable<SubIncisos>> GetSubIncisosAsync()
        {
            var subincisos = new List<SubIncisos>();

            try
            {
                subincisos = await this._context
                                        .SubIncisos
                                        .Include(i => i.Inciso)
                                        .OrderBy(a => a.SubIncisoID)
                                        .ToListAsync();

            }
            catch (Exception)
            {
                throw;
            }

            return subincisos;
        }

        public async Task<ItemsVerificablesViewModel> GetItemsVerificablesAsync(int LeyID)
        {
            ItemsVerificablesViewModel items = null;
            try
            {
                var articulos = await this._context.Articulos.Where(a => a.Verificable == true && a.Capitulo.Titulo.LeyID == LeyID).Select(a => new ArticuloViewModel {
                    ArticuloID = a.ArticuloID,
                    Descripcion = a.Descripcion,
                    Detalle = a.Detalle,
                    CapituloID = a.CapituloID,
                    Verificable = a.Verificable
                }).ToListAsync();

                var incisos = await this._context.Incisos.Where(i => i.Verificable == true && i.Articulo.Capitulo.Titulo.LeyID == LeyID).Select(i => new IncisoViewModel {
                    IncisoID = i.IncisoID,
                    Descripcion = i.Descripcion,
                    Detalle = i.Detalle,
                    ArticuloID = i.ArticuloID,
                    Verificable = i.Verificable
                }).ToListAsync();

                var subIncisos = await this._context.SubIncisos.Where(s => s.Verificable == true && s.Inciso.Articulo.Capitulo.Titulo.LeyID == LeyID).Select(s => new SubIncisoViewModel
                {
                    SubIncisoID = s.SubIncisoID,
                    Descripcion = s.Descripcion,
                    Detalle = s.Detalle,
                    IncisoID = s.IncisoID,
                    Verificable = s.Verificable
                }).ToListAsync();

                items = new ItemsVerificablesViewModel()
                {
                    Articulos = articulos,
                    Incisos = incisos,
                    SubIncisos = subIncisos
                };
            }
            catch (Exception)
            {
                throw;
            }

            return items;
        }

        public async Task<bool> CreateVerificacionAsync(ItemsVerificablesViewModel model)
        {
            bool created = false;
            try
            {
                if(model != null)
                {
                    if(model.LeyID > 0 && model.OrganizacionID > 0)
                    {
                        // Insertar en la tabla Verificacion
                        var verificacion = new Verificacion()
                        {
                            LeyID = model.LeyID,
                            OrganizacionID = model.OrganizacionID,
                            FechaIngreso = DateTime.Now,
                            Usuario = model.User
                        };

                        _context.Verificaciones.Add(verificacion) ;
                        await _context.SaveChangesAsync();

                        if(model.Articulos.Count > 0)
                        {
                            var cumplimientoArticulos = model.Articulos.Select(a => new CumplimientoArticulo
                            {
                                VerificacionID = verificacion.VerificacionID,
                                Cumple = a.Cumple,
                                Evidencia = a.Evidencia,
                                ArticuloID = a.ArticuloID,                                
                            });
                            _context.CumplimientosArticulos.AddRange(cumplimientoArticulos);
                            await _context.SaveChangesAsync();
                        }

                        if (model.Incisos.Count > 0)
                        {
                            var cumplimientoIncisos = model.Incisos.Select(i => new CumplimientoInciso
                            {
                                VerificacionID = verificacion.VerificacionID,
                                Cumple = i.Cumple,
                                Evidencia = i.Evidencia,
                                IncisoID = i.IncisoID,
                            });
                            _context.CumplimientosIncisos.AddRange(cumplimientoIncisos);
                            await _context.SaveChangesAsync();
                        }

                        if (model.SubIncisos.Count > 0)
                        {
                            var cumplimientoSubIncisos = model.SubIncisos.Select(si => new CumplimientoSubInciso
                            {
                                VerificacionID = verificacion.VerificacionID,
                                Cumple = si.Cumple,
                                Evidencia = si.Evidencia,
                                SubIncisoID = si.SubIncisoID,
                            });
                            _context.CumplimientosSubIncisos.AddRange(cumplimientoSubIncisos);
                            await _context.SaveChangesAsync();
                        }
                    }
                    created = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return created;
        }

        public async Task<bool> CreateOrganizacionAsync(OrganizacionViewModel model)
        {
            bool created;
            try
            {
                var organizacion = new Organizacion()
                {
                    Nombre = model.Nombre
                };

                _context.Organizaciones.Add(organizacion);
                await _context.SaveChangesAsync();

                created = true;
            }
            catch (Exception)
            {
                throw;
            }
            return created;
        }

        public async Task<bool> CreateLeyAsync(LeyesViewModel model)
        {
            bool created;
            try
            {
                var ley = new Leyes()
                {
                    Descripcion = model.Descripcion
                };

                _context.Leyes.Add(ley);
                await _context.SaveChangesAsync();

                created = true;
            }
            catch (Exception)
            {
                throw;
            }
            return created;
        }
        public async Task<bool> CreateTituloAsync(TituloViewModel model)
        {
            bool created;
            try
            {
                var titulo = new Titulos()
                {
                    Descripcion = model.Descripcion,
                    Detalle = model.Detalle,
                    LeyID = model.LeyID
                };

                _context.Titulos.Add(titulo);
                await _context.SaveChangesAsync();

                created = true;
            }
            catch (Exception)
            {
                throw;
            }
            return created;
        }

        public async Task<bool> CreateCapituloAsync(CapituloViewModel model)
        {
            bool created;
            try
            {
                var capitulo = new Capitulos()
                {
                    Descripcion = model.Descripcion,
                    Detalle = model.Detalle,
                    TituloID = model.TituloID
                };

                _context.Capitulos.Add(capitulo);
                await _context.SaveChangesAsync();

                created = true;
            }
            catch (Exception)
            {
                throw;
            }
            return created;
        }

        public async Task<IEnumerable<Verificacion>> GetVerificacionesAsync()
        {
            var Verificaciones = new List<Verificacion>();
            try
            {

                Verificaciones = await this._context.Verificaciones.Include(l => l.Ley)
                                            .Include(o => o.Organizacion)
                                            .OrderBy(a => a.FechaIngreso)                                            
                                            .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return Verificaciones;
        }

        public async Task<bool> CreateArticuloAsync(ArticuloViewModel model)
        {
            bool created;
            try
            {
                var articulo = new Articulos()
                {
                    Descripcion = model.Descripcion,
                    Detalle = model.Detalle,
                    CapituloID = model.CapituloID,
                    Verificable = model.Verificable
                };

                _context.Articulos.Add(articulo);
                await _context.SaveChangesAsync();

                created = true;
            }
            catch (Exception)
            {
                throw;
            }
            return created;
        }

        public async Task<bool> CreateIncisoAsync(IncisoViewModel model)
        {
            bool created;
            try
            {
                var inciso = new Incisos()
                {
                    Descripcion = model.Descripcion,
                    Detalle = model.Detalle,
                    ArticuloID = model.ArticuloID,
                    Verificable = model.Verificable
                };

                _context.Incisos.Add(inciso);
                await _context.SaveChangesAsync();

                created = true;
            }
            catch (Exception)
            {
                throw;
            }
            return created;
        }

        public async Task<bool> CreateSubIncisoAsync(SubIncisoViewModel model)
        {
            bool created;
            try
            {
                var subinciso = new SubIncisos()
                {
                    Descripcion = model.Descripcion,
                    Detalle = model.Detalle,
                    IncisoID = model.IncisoID,
                    Verificable = true
                };

                _context.SubIncisos.Add(subinciso);
                await _context.SaveChangesAsync();

                created = true;
            }
            catch (Exception)
            {
                throw;
            }
            return created;
        }
    }    
}
