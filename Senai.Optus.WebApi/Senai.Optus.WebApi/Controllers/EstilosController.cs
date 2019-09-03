using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstilosRepository estilosRepository = new EstilosRepository();

        public IActionResult Listar()
        {
            return Ok(estilosRepository.Listar());
        }

        [HttpPost]

        public IActionResult Cadastrar(Estilos estilos)
        {
            estilosRepository.Cadastrar(estilos);
            return Ok();
        }

        [HttpPut]

        public IActionResult Atuliazar(Estilos estilos)
        {
            estilosRepository.Atualizar(estilos);
            return Ok();
        }

    [HttpDelete("{id}")]

    public IActionResult Deletar(int id)
        {
            estilosRepository.Deletar(id);
            return Ok();
        }
    }
}