using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MASI_MarcoLegal.Server.Models;
using MASI_MarcoLegal.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MASI_MarcoLegal.Server.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizacionesController : ControllerBase
    {
        private readonly IOrganizacionesService _organizacionesService;

        public OrganizacionesController(IOrganizacionesService organizacionesService) => this._organizacionesService = organizacionesService;

        [HttpGet]
        public async Task<IEnumerable<Organizacion>> GetOrganizacionesAsync()
        {
            return await this._organizacionesService.GetOrganizacionesAsync();
        }
    }
}
