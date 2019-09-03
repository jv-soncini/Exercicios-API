using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repositories;

namespace Senai.BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        LivrosRepository livroRepository = new LivrosRepository();

        [HttpGet]
        public IEnumerable<LivrosDomain> Listar()
        {
            return livroRepository.Listar();

        }

        [HttpPost]

        public IActionResult Cadastrar(LivrosDomain livrosDomain)
        {
            livroRepository.Cadastrar(livrosDomain);
            return Ok();
        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            livroRepository.BuscarPorId(id);
            return Ok();
        }
    }
}