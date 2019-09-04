using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private IPecasRepository PecasRepository { get; set; }

        PecasController()
        {
            PecasRepository = new PecasRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PecasRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Pecas pecas)
        {
            PecasRepository.Cadastrar(pecas);
            return Ok();
        }


        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            PecasRepository.BuscarPorId(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualiazar(Pecas pecas, int id)
        {
            pecas.IdPeca = id;
            PecasRepository.Atualizar(pecas);
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar (int id)
        {
            PecasRepository.Deletar(id);
            return Ok();
        }
    }
}