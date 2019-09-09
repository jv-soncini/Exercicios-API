using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface IClassificacao
    {
        List<Classificacao> Listar();
        void Cadastrar(Classificacao classificacao);
        void Atualizar(Classificacao classificacao);
    }
}
