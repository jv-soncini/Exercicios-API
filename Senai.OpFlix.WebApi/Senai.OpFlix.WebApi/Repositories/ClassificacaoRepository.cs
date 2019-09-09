using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class ClassificacaoRepository : IClassificacao
    {
        public void Atualizar(Classificacao classificacao)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Classificacao ClassificacaoBuscada = ctx.Classificacao.FirstOrDefault(x => x.IdClassificacao == classificacao.IdClassificacao);
            ctx.Classificacao.Update(ClassificacaoBuscada);
            ctx.SaveChanges();

            }
        }

        public void Cadastrar(Classificacao classificacao)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Classificacao.Add(classificacao);
                ctx.SaveChanges();
            }
        }

        public List<Classificacao> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Classificacao.ToList();
            }
        }
    }
}
