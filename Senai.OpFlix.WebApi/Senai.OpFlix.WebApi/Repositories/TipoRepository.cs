using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class TipoRepository : ITipoLancamento
    {
        public void Atualizar(TipoLancamento tipoLancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                TipoLancamento TipoBuscado = ctx.TipoLancamento.FirstOrDefault(x => x.IdTipo == tipoLancamento.IdTipo);
                ctx.TipoLancamento.Update(TipoBuscado);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(TipoLancamento tipoLancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.TipoLancamento.Add(tipoLancamento);
                ctx.SaveChanges();
            }
        }

        public List<TipoLancamento> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.TipoLancamento.ToList();
            }
        }
    }
}
