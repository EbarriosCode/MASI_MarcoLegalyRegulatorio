using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using MASI_MarcoLegal.Shared.Local;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MASI_MarcoLegal.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountsController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<UserToken>> CreateUser([FromBody] UserInfo model)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Add all new users to the User role
                if (user.Email.Contains("empresa"))
                {
                    await _userManager.AddToRoleAsync(user, "Empresa");
                }

                if (user.Email.Contains("supervisor"))
                {
                    await _userManager.AddToRoleAsync(user, "Supervisor");
                }                

                // Add new users whose email starts with 'admin' to the Admin role
                if (user.Email.StartsWith("admin"))
                {
                    await _userManager.AddToRoleAsync(user, "Administrador");
                }

                return await BuildToken(model);
            }
            else
            {
                return BadRequest("Usuario y/o password inválidos");
            }

        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserToken>> Login([FromBody] UserInfo userInfo)
        {
            var result = await _signInManager.PasswordSignInAsync(userInfo.Email, userInfo.Password, isPersistent: false, lockoutOnFailure: false);
            
            if (result.Succeeded)
            {
                return await BuildToken(userInfo);
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }

        private async Task<UserToken> BuildToken(UserInfo userInfo)
        {
            //var claims = new[]
            //{
            //    new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email),
            //    new Claim(ClaimTypes.Name, userInfo.Email),
            //    //new Claim("miValor", "Lo que yo quiera"),
            //    new Claim(ClaimTypes.Role, ""),
            //    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            //};
            var user = await _signInManager.UserManager.FindByEmailAsync(userInfo.Email);
            var roles = await _signInManager.UserManager.GetRolesAsync(user);

            var claims = new List<Claim>();

            claims.Add(new Claim(JwtRegisteredClaimNames.UniqueName, userInfo.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.Email));

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Tiempo de expiración del token. En nuestro caso lo hacemos de una hora.
            var expiration = DateTime.UtcNow.AddYears(1);

            JwtSecurityToken token = new JwtSecurityToken(
               _configuration["JwtIssuer"],
               _configuration["JwtAudience"],
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