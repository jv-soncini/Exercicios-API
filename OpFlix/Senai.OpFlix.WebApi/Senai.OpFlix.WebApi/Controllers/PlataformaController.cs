using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        private IPlataformaRepository PlataformaRepository { get; set; }

        public PlataformaController()
        {
            PlataformaRepository = new PlataformaRepository();
        }

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(PlataformaRepository.Listar());
        }

        [HttpPost]

        public IActionResult Cadastrar(Plataforma plataforma)
        {
            PlataformaRepository.Cadastrar(plataforma);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(Plataforma plataforma, int id)
        {
            plataforma.IdPlataforma = id;
            PlataformaRepository.Atualizar(plataforma);
            return Ok();
        }
    }
}