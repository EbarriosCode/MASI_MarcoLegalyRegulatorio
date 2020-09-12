using MASI_MarcoLegal.Server.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Middlerware
{
    public static class IoC
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inyectar el servicio de Leyes
            services.AddTransient<IMarcolegalService, MarcoLegalService>();

            // Inyectar el servicio de Organizaciones
            services.AddTransient<IOrganizacionesService, OrganizacionesService>();

            //Inyecta los servicio de Resultado
            services.AddTransient<IResultadosServices, ResultadosServices>();

            return services;
        }
    }
}
