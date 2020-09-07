using MASI_MarcoLegal.Server.Models;
using MASI_MarcoLegal.Server.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Controllers
{    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class LeyesController : ControllerBase
    {
        private readonly ILeyesService _leyesService;

        public LeyesController(ILeyesService leyesService) => this._leyesService = leyesService;

        [HttpGet]
        public async Task<IEnumerable<Leyes>> GetLeyesAsync()
        {
            return await this._leyesService.GetLeyesAsync();
        }
    }
}
