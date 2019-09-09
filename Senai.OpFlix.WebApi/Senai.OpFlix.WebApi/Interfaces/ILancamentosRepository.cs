using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    interface ILancamentosRepository
    {
        Lancamentos BuscarPorId(int id);
        List<Lancamentos> Listar();
        void Cadastrar(Lancamentos lancamentos);
        void Atualizar(Lancamentos lancamentos);
        void Deletar(int id);
    }
}
