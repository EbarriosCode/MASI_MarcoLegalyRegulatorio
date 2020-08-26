using MASI_MarcoLegal.Server.DataContext;
using MASI_MarcoLegal.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Services
{
    public interface ILeyesService
    {
        Task<IEnumerable<Leyes>> GetLeyesAsync();
    }
    public class LeyesService : ILeyesService
    {
        private readonly MASIContext _context;

        public LeyesService(MASIContext context) => this._context = context;

        public async Task<IEnumerable<Leyes>> GetLeyesAsync()
        {
            var leyes = new List<Leyes>();
            try
            {
                leyes = await this._context
                                        .Leyes
                                        .AsNoTracking()
                                        .AsQueryable()
                                        .Include(l => l.Considerandos)
                                        .Include(l => l.Titulos)
                                        .ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }

            return leyes;
        }
    }
}
