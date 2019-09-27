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
    public class FornecedorController : ControllerBase
    {

        private IFornecedoresRepository FornecedoresRepository { get; set; }

        public FornecedorController ()
        {
            FornecedoresRepository = new FornecedorRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FornecedoresRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Fornecedores fornecedores)
        {
            FornecedoresRepository.Cadastrar(fornecedores);
            return Ok();
        }
    }
}