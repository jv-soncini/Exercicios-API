using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {


        CategoriaRepository categoriaRepository = new CategoriaRepository();

        [HttpGet]
        [Authorize(Roles = "ADMINISTRADOR")]
        public IActionResult Listar()
        {
            return Ok(categoriaRepository.Listar());
        }

        [HttpPost]

        public IActionResult Cadastrar(Categorias categorias)
        {
            try
            {
                categoriaRepository.Cadastrar(categorias);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "eita, erro" } + ex.Message);
            }
        }

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            Categorias categorias = categoriaRepository.BuscarPorId(id);
            if (categorias == null)
            {
                return NotFound();
            }
            return Ok(categorias);
        }

        [HttpDelete("{id}")]

        public IActionResult Deletar(int id)
        {
            categoriaRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]

        public IActionResult Atualizar(Categorias categorias)
        {
            try
            {
                Categorias categoriaBuscada = categoriaRepository.BuscarPorId(categorias.IdCategoria);

                if (categoriaBuscada == null)
                {
                    return NotFound();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "ja avisei que vai dar merda" } + ex.Message);
            }
        }
    }
}