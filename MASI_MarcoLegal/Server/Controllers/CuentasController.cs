using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MASI_MarcoLegal.Server.DataContext;
using MASI_MarcoLegal.Server.Helpers;
using MASI_MarcoLegal.Server.Models;
using MASI_MarcoLegal.Shared.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MASI_MarcoLegal.Server.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class CuentasController : ControllerBase
        {
            private readonly IConfiguration _configuration;
            private readonly MASIContext context;



        public CuentasController(IConfiguration configuration, MASIContext _context)
        {
            _configuration = configuration;
            context = _context;
            }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Usuarios>>> Get([FromQuery] Paginacion paginacion,
      [FromQuery] string nombre)
        {
            var queryable = context.Usuarios.AsQueryable();
            if (!string.IsNullOrEmpty(nombre))
            {
                queryable = queryable.Where(x => x.Nombres.Contains(nombre));
            }
            await HttpContext.InsertarParametrosPaginacionEnRespuesta(queryable, paginacion.CantidadAMostrar);
            return await queryable.Paginar(paginacion).ToListAsync();
        }

        [Authorize]
        [HttpGet("{id}", Name = "obtenerUsuario")]
        public async Task<ActionResult<Usuarios>> Get(int id)
        {
            var usuario = await context.Usuarios.Include(x => x.Rol).FirstOrDefaultAsync(x => x.UsuarioID == id);
                usuario.Password = "";
            return usuario;
        }

        [Authorize]
        [HttpPost("Crear")]
        public async Task<ActionResult<String>> CreateUser(Usuarios model)
        {

            context.Usuarios.Add(model);
            await context.SaveChangesAsync();

            return Ok("Usuario Creado");
            }


        [HttpPut("editar")]
        public async Task<ActionResult> Put(Usuarios model)
        {
            context.Entry(model).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }

        [Authorize]
        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var usuarios = new Usuarios { UsuarioID = id };
            context.Remove(usuarios);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UsuarioLogin user)
        {
            var result = await context.Usuarios.Include(l => l.Rol ).FirstOrDefaultAsync(usuario => (usuario.Usuario == user.Username) && (usuario.Password == user.Password));
                if (result != null)
                {
                    return BuildToken(result);
                }
                else
                {
                    return BadRequest("Usuario o Contraseña invalidos");
                }
            }

            private UserToken BuildToken(Usuarios user)
            {
            var claims = new List<Claim>();

                claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, user.Usuario));
                claims.Add(new Claim(ClaimTypes.Name, user.Usuario));
                claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

            if(user.Rol != null)
            {
                claims.Add(new Claim(ClaimTypes.Role, user.Rol.Rol));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Tiempo de expiración del token. En nuestro caso lo hacemos de una hora.
                var expiration = DateTime.UtcNow.AddYears(1);

                JwtSecurityToken token = new JwtSecurityToken(
                   issuer: null,
                   audience: null,
                   claims: claims,
                   expires: expiration,
                   signingCredentials: creds);
                return new UserToken()
                {
                    Token = new JwtSecurityTokenHandler().WriteToken(token),
                    Expiration = expiration
                };
            }
        }
}
