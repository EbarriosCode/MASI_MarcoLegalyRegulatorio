using MASI_MarcoLegal.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.DataContext
{
    public class MASIContext : IdentityDbContext
    {
        public MASIContext(DbContextOptions<MASIContext> options)
            : base(options) { }

        public DbSet<Organizacion> Organizaciones { get; set; }
        public DbSet<Leyes> Leyes { get; set; }
        public DbSet<Considerandos> Considerandos { get; set; }
        public DbSet<Titulos> Titulos { get; set; }
        public DbSet<Capitulos> Capitulos { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Incisos> Incisos { get; set; }
        public DbSet<LeyOrganizacion> LeyesOrganizaciones { get; set; }
        public DbSet<Cumplimientos> Cumplimientos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LeyOrganizacion>()
                .HasKey(lo=> new { lo.OrganizacionID, lo.LeyID });

            modelBuilder.Entity<LeyOrganizacion>()
                .HasOne(o => o.Organizacion)
                .WithMany(o => o.LeyesOrganizaciones)
                .HasForeignKey(o => o.OrganizacionID);

            modelBuilder.Entity<LeyOrganizacion>()
                .HasOne(l => l.Ley)
                .WithMany(l => l.LeyesOrganizaciones)
                .HasForeignKey(l => l.LeyID);

            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Empresa", NormalizedName = "EMPRESA", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            //modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
        }
    }
}
