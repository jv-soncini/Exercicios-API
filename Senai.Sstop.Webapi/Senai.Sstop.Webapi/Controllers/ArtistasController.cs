using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.Webapi.Domains;
using Senai.Sstop.Webapi.Repositories;

namespace Senai.Sstop.Webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        ArtistaRepository artistaRepository = new ArtistaRepository();

        public IActionResult Listar()
        {
            return Ok(artistaRepository.Listar()); 
        }

        [HttpPost]

        public IActionResult Cadastrar(ArtistaDomain artistaDomain)
        {

            try
            {
                artistaRepository.Cadastrar(artistaDomain);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Foi mal, a situação não ta legal ;-;  " + ex.Message });
            }

            
        }
    }
}