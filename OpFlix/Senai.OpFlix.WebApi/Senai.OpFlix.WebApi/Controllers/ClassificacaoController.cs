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
    public class ClassificacaoController : ControllerBase
    {
        private IClassificacao ClassificacaoRepository { get; set; }

        public ClassificacaoController()
        {
            ClassificacaoRepository = new ClassificacaoRepository();
        }

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(ClassificacaoRepository.Listar());
        }

        [HttpPost]

        public IActionResult Cadastrar(Classificacao classificacao)
        {
            ClassificacaoRepository.Cadastrar(classificacao);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(Classificacao classificacao, int id)
        {
            classificacao.IdClassificacao = id;
            ClassificacaoRepository.Atualizar(classificacao);
            return Ok();
        }
    }
}