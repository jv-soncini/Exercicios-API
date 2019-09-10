using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;
using Senai.OpFlix.WebApi.ViewModel;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuariosRepository UsuariosRepository { get; set; }

        public UsuarioController()
        {
            UsuariosRepository = new UsuarioRepository();
        }

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(UsuariosRepository.Listar());
        }

        [HttpPost]

        public IActionResult Cadastrar(Usuarios usuarios)
        {
            UsuariosRepository.Cadastrar(usuarios);
            return Ok();
        }


        [HttpPost("Login")]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios Usuario = UsuariosRepository.Login(login);
                if (Usuario == null)
                {
                    return NotFound(new { mensagem = "Email ou senha inválidos." });
                }

                var claims = new[]
                {
                   
                    new Claim(JwtRegisteredClaimNames.Email, Usuario.Email),
                    new Claim("chave", "valor"),
                    
                    new Claim(JwtRegisteredClaimNames.Jti, Usuario.IdUsuarios.ToString()),
                    // é a permissão do usuário
                    new Claim(ClaimTypes.Role, Usuario.Permissao),
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("OpFlix-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "OpFlix.WebApi",
                    audience: "OpFlix.WebApi",
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