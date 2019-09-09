using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("applicarion/json")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }

        CategoriaController()
        {
            CategoriaRepository = new CategoriaRepository();
        }
    }
}