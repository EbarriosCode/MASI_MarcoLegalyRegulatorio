using MASI_MarcoLegal.Server.Models;
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
                if (_context.Leyes.Any()) return;

                var leyes = new Leyes[]
                {
                    new Leyes { Descripcion = "Reglamento de Seguridad Cibernética y de la Información – GDC (República Dominicana)" }
                };

                _context.Leyes.AddRange(leyes);
                _context.SaveChanges();

                // Agregar Considerandos
                if (_context.Considerandos.Any()) return;

                var considerandos = new Considerandos[]
                {
                    new Considerandos()
                    {
                        Descripcion = "que expresa la Gerencia del Banco Central, que esta normativa ha sido desarrollada como respuesta a los incidentes de seguridad cibernética",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    },
                    new Considerandos()
                    {
                        Descripcion = "que indica la Gerencia del Banco Central, que se elaboró un Proyecto de Reglamento bajo los estándares más modernos en la materia, que vienen a cubrir el vacío normativo",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    }
                };

                _context.Considerandos.AddRange(considerandos);

                // Agregar Títulos
                if (_context.Titulos.Any()) return;

                var titulos = new Titulos[]
                {
                    new Titulos()
                    {
                        Descripcion = "TITULO I",
                        Detalle = "DISPOSICIONES GENERALES",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    },
                    new Titulos()
                    {
                        Descripcion = "TITULO II",
                        Detalle = "DEL PROGRAMA DE LA SEGURIDAD CIBERNÉTICA Y DE LA INFORMACIÓN",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    },
                    new Titulos()
                    {
                        Descripcion = "TITULO III",
                        Detalle = "COORDINACIÓN SECTORIAL DE RESPUESTA A INCIDENTES DE SEGURIDAD CIBERNÉTICA",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    },
                    new Titulos()
                    {
                        Descripcion = "TITULO IV",
                        Detalle = "DISPOSICIONES FINALES",
                        LeyID = leyes.FirstOrDefault(l => l.Descripcion.Contains(leyes[0].Descripcion)).LeyID
                    }
                };

                _context.Titulos.AddRange(titulos);
                _context.SaveChanges();

                // Agregar Capitulos              
                if (_context.Capitulos.Any()) return;

                var capitulos = new Capitulos[]
                {
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO I",
                        Detalle = "OBJETO, ALCANCE, ÁMBITO DE LA APLICACIÓN Y PRINCIPIOS RECTORES",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[0].Detalle)).TituloID
                    },
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO II",
                        Detalle = "DEFINICIONES",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[0].Detalle)).TituloID
                    },
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO III",
                        Detalle = "MARCO DE TRABAJO Y ESTRUCTURA DE LA GOBERNANZA PARA EL PROGRAMA DE SEGURIDAD CIBERNÉTICA Y DE LA INFORMACIÓN",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[0].Detalle)).TituloID
                    },
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO I",
                        Detalle = "GESTIÓN DEL RIESGO TECNOLÓGICO",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[1].Detalle)).TituloID
                    },
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO II",
                        Detalle = "MARCO DE CONTROL DE SEGURIDAD CIBERNÉTICA Y DE LA INFORMACIÓN",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[1].Detalle)).TituloID
                    },
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO III",
                        Detalle = "MONITOREO Y EVALUACIÓN",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[1].Detalle)).TituloID
                    },
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO IV",
                        Detalle = "ESTÁNDARES INTERNACIONALES",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[1].Detalle)).TituloID
                    },
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO V",
                        Detalle = "INFORMES DE CUMPLIMIENTO",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[1].Detalle)).TituloID
                    },
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO I",
                        Detalle = "GOBERNANZA",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[2].Detalle)).TituloID
                    },
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO II",
                        Detalle = "DEL MECANISMO SECTORIAL DE RESPUESTA A INCIDENTES DE SEGURIDAD CIBERNÉTICA",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[2].Detalle)).TituloID
                    },
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO I",
                        Detalle = "RÉGIMEN SANCIONATORIO Y MEDIDAS PRECAUTORIAS",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[3].Detalle)).TituloID
                    },
                    new Capitulos()
                    {
                        Descripcion = "CAPITULO II",
                        Detalle = "OTRAS DISPOSICIONES",
                        TituloID = titulos.FirstOrDefault(t => t.Detalle.Contains(titulos[3].Detalle)).TituloID
                    }
                };

                _context.Capitulos.AddRange(capitulos);
                _context.SaveChanges();

                // Agregar Articulos              
                if (_context.Articulos.Any()) return;

                var articulos = new Articulos[]
                {
                    // Capítulo I
                    new Articulos()
                    {
                        Descripcion = "Artículo 1.",
                        Detalle = "Objeto.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[0].Detalle)).CapituloID
                    },
                    new Articulos()
                    {
                        Descripcion = "Artículo 2.",
                        Detalle = "Alcance.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[0].Detalle)).CapituloID
                    },
                    new Articulos()
                    {
                        Descripcion = "Artículo 3.",
                        Detalle = "Ámbito de Aplicación.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[0].Detalle)).CapituloID
                    },
                    new Articulos()
                    {
                        Descripcion = "Artículo 4.",
                        Detalle = "Principios Rectores.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[0].Detalle)).CapituloID
                    },
                    // Capítulo II
                    new Articulos()
                    {
                        Descripcion = "Artículo 5.",
                        Detalle = "Definiciones.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[1].Detalle)).CapituloID
                    },
                    // Capítulo III
                    new Articulos()
                    {
                        Descripcion = "Artículo 6.",
                        Detalle = "Marco de Trabajo.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[2].Detalle)).CapituloID
                    },
                    new Articulos()
                    {
                        Descripcion = "Artículo 7.",
                        Detalle = "Estructura.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[2].Detalle)).CapituloID
                    },
                    new Articulos()
                    {
                        Descripcion = "Artículo 8.",
                        Detalle = "Aprobación del Programa de Seguridad Cibernética y de la Información.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[2].Detalle)).CapituloID
                    },
                    new Articulos()
                    {
                        Descripcion = "Artículo 9.",
                        Detalle = "Responsabilidades del Comité Funcional de Seguridad Cibernética y de la Información.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[2].Detalle)).CapituloID
                    },
                     new Articulos()
                    {
                        Descripcion = "Artículo 10.",
                        Detalle = "Oficial de Seguridad Cibernética y de la Información.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[2].Detalle)).CapituloID
                    },
                    new Articulos()
                    {
                        Descripcion = "Artículo 11.",
                        Detalle = "Responsabilidades del Oficial de Seguridad Cibernética y de la Información.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[2].Detalle)).CapituloID
                    },
                    new Articulos()
                    {
                        Descripcion = "Artículo 12.",
                        Detalle = "Áreas Especializadas.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[2].Detalle)).CapituloID
                    },
                    new Articulos()
                    {
                        Descripcion = "Artículo 13.",
                        Detalle = "Gestión de Riesgos Tecnológicos.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[3].Detalle)).CapituloID
                    },
                    new Articulos()
                    {
                        Descripcion = "Artículo 14.",
                        Detalle = "Gestión de Riesgos Tecnológicos en las Entidades Interconectadas.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[3].Detalle)).CapituloID
                    },
                    new Articulos()
                    {
                        Descripcion = "Artículo 15.",
                        Detalle = "Metodologías para la Gestión de Riesgos Tecnológicos.",
                        CapituloID = capitulos.FirstOrDefault(c => c.Detalle.Contains(capitulos[3].Detalle)).CapituloID
                    }
                };

                _context.Articulos.AddRange(articulos);
                _context.SaveChanges();

                // Agregar Incisos              
                if (_context.Incisos.Any()) return;

                var incisos = new Incisos[]
                {
                    new Incisos()
                    {
                        Descripcion = "",
                        Detalle = "",
                        ArticuloID = 1
                    }
                };

                _context.Incisos.AddRange(incisos);
                _context.SaveChanges();
            }
        }

    }
}
