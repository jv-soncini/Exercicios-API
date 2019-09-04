using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;
using Senai.AutoPecas.WebApi.ViewModel;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

       public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }


        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios Usuario = UsuarioRepository.Login(login);
                if (Usuario == null)
                {
                    return NotFound(new { mensagem = "Email ou senha inválidos." });
                }

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, Usuario.Email),
                    new Claim("chave", "Isso é um valor"),
                    new Claim(JwtRegisteredClaimNames.Jti, Usuario.IdUsuarios.ToString()),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("AutoPecas-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "AutoPecas.WebApi",
                    audience: "AutoPecas.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);


                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro." + ex.Message });
            }
        }
    }
}