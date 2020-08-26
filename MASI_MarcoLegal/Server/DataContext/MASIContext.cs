using MASI_MarcoLegal.Server.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.DataContext
{
    public class MASIContext : DbContext
    {
        public MASIContext(DbContextOptions<MASIContext> options)
            : base(options) { }

        public DbSet<Leyes> Leyes { get; set; }
        public DbSet<Considerandos> Considerandos { get; set; }
        public DbSet<Titulos> Titulos { get; set; }
        public DbSet<Capitulos> Capitulos { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Incisos> Incisos { get; set; }        
    }
}
