using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        ArtistasRepository artistasRepository = new ArtistasRepository();

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(artistasRepository.Listar());
        }

        [HttpPost]

        public IActionResult Cadastrar(Artistas artistas)
        {
            artistasRepository.Cadastrar(artistas);
            return Ok();
        }
    }
}