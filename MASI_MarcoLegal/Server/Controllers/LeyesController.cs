using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MASI_MarcoLegal.Server.Models;
using MASI_MarcoLegal.Server.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MASI_MarcoLegal.Server.Controllers
{
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
