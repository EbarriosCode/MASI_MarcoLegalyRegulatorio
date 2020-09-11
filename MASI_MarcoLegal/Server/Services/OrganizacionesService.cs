using MASI_MarcoLegal.Server.DataContext;
using MASI_MarcoLegal.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Services
{
    public interface IOrganizacionesService
    {
        Task<IEnumerable<Organizacion>> GetOrganizacionesAsync();
    }
    public class OrganizacionesService : IOrganizacionesService
    {
        private readonly MASIContext _context;

        public OrganizacionesService(MASIContext context) => this._context = context;

        public async Task<IEnumerable<Organizacion>> GetOrganizacionesAsync()
        {
            var organzaciones = new List<Organizacion>();
            try
            {
                organzaciones = await this._context
                                        .Organizaciones
                                        .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return organzaciones;
        }
    }
}
