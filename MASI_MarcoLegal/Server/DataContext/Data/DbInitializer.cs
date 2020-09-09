using MASI_MarcoLegal.Server.Models;
using MASI_MarcoLegal.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MASI_MarcoLegal.Server.DataContext.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var _context = new MASIContext(serviceProvider.GetRequiredService<DbContextOptions<MASIContext>>()))
            {
                // Agregando Leyes a la BD
                if (_context.Roles.Any()) return;

                var roles = new Roles[]
                {
                    new Roles { Rol ="supervisor" },
                    new Roles { Rol ="institucion"},
                    new Roles { Rol ="admin"}
                };

                _context.Roles.AddRange(roles);

                _context.SaveChanges();

                if (_context.Usuarios.Any()) return;

                var usuarios = new Usuarios[]
                {
                    new Usuarios { Nombres="admin",
                        Apellidos="Admin",
                        Correo="admin@gmail.com",
                        Password="manager1",
                        Puesto="admin",
                        RolId = roles.FirstOrDefault(l => l.Rol.Contains("admin")).RolId,
                        Usuario="admin"
                    }
                };

                _context.Usuarios.AddRange(usuarios);

                _context.SaveChanges();
                // Agregando Leyes a la BD
                if (_context.Leyes.Any()) return;

                var leyes = new Leyes[]
                {
                    new Leyes { Descripcion = "Reglamento de Seguridad Cibernética y de la Información – GDC (República Dominicana)" }
                };

                _context.Leyes.AddRange(leyes);

                _context.SaveChanges();

                // Agregar Considerandos
                if (_context.Considerandos.Any()) return;

                _context.Considerandos.AddRange(
                    new Considerandos()
                    {                        
                        Descripcion = "que expresa la Gerencia del Banco Central, que esta normativa ha sido desarrollada como respuesta a los incidentes de seguridad cibernética",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    },
                    new Considerandos()
                    {                    
                        Descripcion = "que indica la Gerencia del Banco Central, que se elaboró un Proyecto de Reglamento bajo los estándares más modernos en la materia, que vienen a cubrir el vacío normativo",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    });               

                // Agregar Títulos
                if (_context.Titulos.Any()) return;

                _context.Titulos.AddRange(
                    new Titulos()
                    {                        
                        Descripcion = "TITULO I \n DISPOSICIONES GENERALES",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    },
                    new Titulos()
                    {                        
                        Descripcion = "TITULO II \n DEL PROGRAMA DE LA SEGURIDAD CIBERNÉTICA Y DE LA INFORMACIÓN",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    },
                    new Titulos()
                    {                        
                        Descripcion = "TITULO III \n COORDINACIÓN SECTORIAL DE RESPUESTA A INCIDENTES DE SEGURIDAD CIBERNÉTICA",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    },
                    new Titulos()
                    {                        
                        Descripcion = "TITULO IV \n DISPOSICIONES FINALES",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    });

                _context.SaveChanges();
            }
        }

    }
}
