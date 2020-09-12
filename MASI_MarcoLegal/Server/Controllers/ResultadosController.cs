using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using MASI_MarcoLegal.Server.Services;
using MASI_MarcoLegal.Shared.ViewModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MASI_MarcoLegal.Server.Controllers
{
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadosController : ControllerBase
    {

        private readonly IResultadosServices _resultadoService;

        public ResultadosController(IResultadosServices resultadosService) => this._resultadoService = resultadosService;

        [HttpGet("GetResultado/{VerificacionId}")]
        public async Task<ResultadosViewModel> GetResultadoAsync(int VerificacionId)
        {
            return await _resultadoService.GetResultadoAsync(VerificacionId);
        }

        [HttpGet("GetDetalleArticulos/{VerificacionId}")]
        public async Task<IEnumerable<DetalleResultadoViewModel>> GetDetalleArticulosAsync(int VerificacionId)
        {
            return await _resultadoService.GetDetalleArticuloAsync(VerificacionId);
        }

        [HttpGet("GetDetalleIncisos/{VerificacionId}")]
        public async Task<IEnumerable<DetalleResultadoViewModel>> GetDetalleIncisosAsync(int VerificacionId)
        {
            return await _resultadoService.GetDetalleIncisoAsync(VerificacionId);
        }

        [HttpGet("GetDetalleSubIncisos/{VerificacionId}")]
        public async Task<IEnumerable<DetalleResultadoViewModel>> GetDetalleSubIncisosAsync(int VerificacionId)
        {
            return await _resultadoService.GetDetalleSubIncisoAsync(VerificacionId);
        }
    }
}
