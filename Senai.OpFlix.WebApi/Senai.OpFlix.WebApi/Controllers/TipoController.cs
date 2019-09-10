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
    public class TipoController : ControllerBase
    {
        private ITipoLancamento TipoRepository { get; set; }

        public TipoController()
        {
            TipoRepository = new TipoRepository();
        }

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(TipoRepository.Listar());
        }

        [HttpPost]

        public IActionResult Cadastrar(TipoLancamento Tipo)
        {
            TipoRepository.Cadastrar(Tipo);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(TipoLancamento Tipo, int id)
        {
            Tipo.IdTipo = id;
            TipoRepository.Atualizar(Tipo);
            return Ok();
        }
    }
}