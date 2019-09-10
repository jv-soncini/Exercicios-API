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
    public class LancamentosController : ControllerBase
    {
        private ILancamentosRepository LancamentoRepository { get; set; }

        public LancamentosController()
        {
            LancamentoRepository = new LancamentosRepository();
        }

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }

        [HttpPost]

        public IActionResult Cadastrar(Lancamentos lancamentos)
        {
            LancamentoRepository.Cadastrar(lancamentos);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(Lancamentos lancamentos, int id)
        {
            lancamentos.IdLancamento = id;
            LancamentoRepository.Atualizar(lancamentos);
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar (int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();
        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            LancamentoRepository.BuscarPorId(id);
            return Ok();
        }
    }
}