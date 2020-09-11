using MASI_MarcoLegal.Server.Models;
using MASI_MarcoLegal.Server.Services;
using MASI_MarcoLegal.Shared.ViewModels;
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
    public class MarcoLegalController : ControllerBase
    {
        private readonly IMarcolegalService _leyesService;

        public MarcoLegalController(IMarcolegalService leyesService) => this._leyesService = leyesService;

        [HttpGet("GetLeyesOrganizaciones")]
        public async Task<IEnumerable<LeyOrganizacion>> GetLeyesOrganizacionesAsync()
        {
            return await this._leyesService.GetLeyesOrganizacionesAsync();
        }

        [HttpGet("GetOrganizaciones")]
        public async Task<IEnumerable<Organizacion>> GetOrganizacionesAsync()
        {
            return await this._leyesService.GetOrganizacionesAsync();
        }

        [HttpGet("GetLeyes")]
        public async Task<IEnumerable<Leyes>> GetLeyesAsync()
        {
            return await this._leyesService.GetLeyesAsync();
        }

        [HttpGet("GetTitulos")]
        public async Task<IEnumerable<Titulos>> GetTitulosAsync()
        {
            return await this._leyesService.GetTitulosAsync();
        }

        [HttpGet("GetCapitulos")]
        public async Task<IEnumerable<Capitulos>> GetCapitulosAsync()
        {
            return await this._leyesService.GetCapitulosAsync();
        }

        [HttpGet("GetArticulos")]
        public async Task<IEnumerable<Articulos>> GetArticulosAsync()
        {
            return await this._leyesService.GetArticulosAsync();
        }

        [HttpGet("GetIncisos")]
        public async Task<IEnumerable<Incisos>> GetIncisosAsync()
        {
            return await this._leyesService.GetIncisosAsync();
        }

        [HttpGet("GetSubIncisos")]
        public async Task<IEnumerable<SubIncisos>> GetSubIncisosAsync()
        {
            return await this._leyesService.GetSubIncisosAsync();
        }

        [HttpGet("GetItemsVerificables/{LeyID}")]
        public async Task<ItemsVerificablesViewModel> GetItemsVerificablesAsync(int LeyID)
        {
            return await _leyesService.GetItemsVerificablesAsync(LeyID);            
        }
    }
}
