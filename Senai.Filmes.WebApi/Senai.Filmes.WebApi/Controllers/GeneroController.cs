using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        List<GeneroDomain> Generos = new List<GeneroDomain>();

        GeneroRepository generoRepository = new GeneroRepository();

        public IEnumerable<GeneroDomain> ListarTodos()
        {
            return generoRepository.Listar();
        }
        [HttpPost]

        public IActionResult Cadastrar(GeneroDomain generos)
        {
            generoRepository.Cadastrar(generos);
            return Ok();
        }

        [HttpGet("{id}")]

        public GeneroDomain BuscarPorId(int id)
        {
            GeneroDomain generoDomain = generoRepository.BuscarPorId(id);
            if (generoDomain == null)
            {
                return null;
            }
            return generoDomain;
        }

        [HttpPut]

        public IActionResult Atualizar(GeneroDomain genero)
        {
            generoRepository.Atualizar(genero);
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar (int id)
        {
            generoRepository.Deletar(id);
            return Ok();
        }
        
    }
}