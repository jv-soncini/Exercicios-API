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
    public class CategoriaController : ControllerBase
    {
        public ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriaController()
        {
            CategoriaRepository = new CategoriaRepository();
        }

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }

        [HttpPost]

        public IActionResult Cadastrar(Categoria categoria)
        {
            CategoriaRepository.Cadastrar(categoria);
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult Atualizar(Categoria categoria, int id)
        {
            categoria.IdCategoria = id;
            CategoriaRepository.Atualizar(categoria);
            return Ok();
        }
    }
}