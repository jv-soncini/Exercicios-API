using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EventosController : ControllerBase
    {
        EventoRepository eventosRepository = new EventoRepository();

        [HttpGet]

        public IActionResult Listar()
        {
            return Ok(eventosRepository.Listar());
        }

        [HttpPost]

        public IActionResult Cadastrar(Eventos eventos )
        {
            try
            {
                eventosRepository.Cadastrar(eventos);
                    return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "ja avisei que vai dar merda" } + ex.Message);
            }
        }
    }
}