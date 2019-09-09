﻿using System;
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
    [Produces("application/json")]
    [ApiController]
    public class ClassificacaoController : ControllerBase
    {
        private IClassificacao ClassificacaoRepository { get; set; }

        ClassificacaoController()
        {
            ClassificacaoRepository = new ClassificacaoRepository();
        }
    }
}