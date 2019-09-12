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
    public class GenerosController : ControllerBase
    {
        GeneroRepository generoRepository = new GeneroRepository();

        [HttpGet]
        public IEnumerable<GenerosDomain> Listar()
        {
            return generoRepository.Listar();

        }

        [HttpPost]

        public IActionResult Cadastrar(GenerosDomain generosDomain)
        {
            generoRepository.Cadastrar(generosDomain);
            return Ok();
        }
    }
}