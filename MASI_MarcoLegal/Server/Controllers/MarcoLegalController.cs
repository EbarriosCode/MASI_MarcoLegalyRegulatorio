using MASI_MarcoLegal.Server.Models;
using MASI_MarcoLegal.Server.Services;
using MASI_MarcoLegal.Shared.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MASI_MarcoLegal.Server.Controllers
{    
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class MarcoLegalController : ControllerBase
    {
        private readonly IMarcolegalService _marcoLegalService;

        public MarcoLegalController(IMarcolegalService marcoLegalService) => this._marcoLegalService = marcoLegalService;

        [HttpGet("GetLeyesOrganizaciones")]
        public async Task<IEnumerable<LeyOrganizacion>> GetLeyesOrganizacionesAsync()
        {
            return await this._marcoLegalService.GetLeyesOrganizacionesAsync();
        }        

        [HttpGet("GetOrganizaciones")]
        public async Task<IEnumerable<Organizacion>> GetOrganizacionesAsync()
        {
            return await this._marcoLegalService.GetOrganizacionesAsync();
        }

        [HttpGet("GetLeyes")]
        public async Task<IEnumerable<Leyes>> GetLeyesAsync()
        {
            return await this._marcoLegalService.GetLeyesAsync();
        }

        [HttpPost("CreateLey")]
        public async Task<IActionResult> CreateLey([FromBody] LeyesViewModel model)
        {
            if (model != null)
            {
                await this._marcoLegalService.CreateLeyAsync(model);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("GetTitulos")]
        public async Task<IEnumerable<Titulos>> GetTitulosAsync()
        {
            return await this._marcoLegalService.GetTitulosAsync();
        }

        [HttpPost("CreateTitulo")]
        public async Task<IActionResult> CreateTitulo([FromBody] TituloViewModel model)
        {
            if (model != null)
            {
                await this._marcoLegalService.CreateTituloAsync(model);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("GetCapitulos")]
        public async Task<IEnumerable<Capitulos>> GetCapitulosAsync()
        {
            return await this._marcoLegalService.GetCapitulosAsync();
        }

        [HttpPost("CreateCapitulo")]
        public async Task<IActionResult> CreateCapitulo([FromBody] CapituloViewModel model)
        {
            if (model != null)
            {
                await this._marcoLegalService.CreateCapituloAsync(model);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("GetArticulos")]
        public async Task<IEnumerable<Articulos>> GetArticulosAsync()
        {
            return await this._marcoLegalService.GetArticulosAsync();
        }

        [HttpPost("CreateArticulo")]
        public async Task<IActionResult> CreateArticulo([FromBody] ArticuloViewModel model)
        {
            if (model != null)
            {
                await this._marcoLegalService.CreateArticuloAsync(model);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("GetIncisos")]
        public async Task<IEnumerable<Incisos>> GetIncisosAsync()
        {
            return await this._marcoLegalService.GetIncisosAsync();
        }

        [HttpPost("CreateInciso")]
        public async Task<IActionResult> CreateInciso([FromBody] IncisoViewModel model)
        {
            if (model != null)
            {
                await this._marcoLegalService.CreateIncisoAsync(model);
                return Ok();
            }

            return BadRequest();
        }

        [HttpPost("CreateSubInciso")]
        public async Task<IActionResult> CreateSubInciso([FromBody] SubIncisoViewModel model)
        {
            if (model != null)
            {                
                await this._marcoLegalService.CreateSubIncisoAsync(model);
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("GetSubIncisos")]
        public async Task<IEnumerable<SubIncisos>> GetSubIncisosAsync()
        {
            return await this._marcoLegalService.GetSubIncisosAsync();
        }

        [HttpGet("GetItemsVerificables/{LeyID}")]
        public async Task<ItemsVerificablesViewModel> GetItemsVerificablesAsync(int LeyID)
        {
            return await _marcoLegalService.GetItemsVerificablesAsync(LeyID);            
        }

        // Crear Validación y Verificación de Cumplimientos
        [HttpPost("InsertCumplimientos")]
        public async Task<IActionResult> InsertCumplimientos([FromBody] ItemsVerificablesViewModel itemsVerificables)
        {
            if(itemsVerificables != null)
            {
                if (itemsVerificables.Articulos.Count > 0)
                {
                    foreach (var item in itemsVerificables.Articulos)
                    {
                        if(item.Cumple)
                            item.Evidencia = $"UpdloaFiles/{Guid.NewGuid()}";
                        //if (!string.IsNullOrEmpty(item.Evidencia))
                        //    item.Evidencia = item.Evidencia.Replace("C:\\fakepath\\", "UploadFiles/");
                    }
                }

                if (itemsVerificables.Incisos.Count > 0)
                {
                    foreach (var item in itemsVerificables.Incisos)
                    {
                        if (item.Cumple)
                            item.Evidencia = $"UpdloaFiles/{Guid.NewGuid()}";
                        //if (!string.IsNullOrEmpty(item.Evidencia))
                        //    item.Evidencia = item.Evidencia.Replace("C:\\fakepath\\", "UploadFiles/");
                    }
                }

                if (itemsVerificables.SubIncisos.Count > 0)
                {
                    foreach (var item in itemsVerificables.SubIncisos)
                    {
                        if (item.Cumple)
                            item.Evidencia = $"UpdloaFiles/{Guid.NewGuid()}";
                        //if (!string.IsNullOrEmpty(item.Evidencia))
                        //    item.Evidencia = item.Evidencia.Replace("C:\\fakepath\\", "UploadFiles/");
                    }
                }

                // Crear los registros invocando al Service
                await this._marcoLegalService.CreateVerificacionAsync(itemsVerificables);
            }
            return Ok();
        }
    }
}
