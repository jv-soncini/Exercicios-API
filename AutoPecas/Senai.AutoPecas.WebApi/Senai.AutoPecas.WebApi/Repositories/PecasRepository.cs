using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecasRepository : IPecasRepository
    {
        public void Atualizar(Pecas pecas)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas pecaRetornada = ctx.Pecas.First(x => x.IdPeca == pecas.IdPeca);
                ctx.Pecas.Update(pecaRetornada);
                ctx.SaveChanges();
            }
        }

        public Pecas BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.IdPeca == id);
            }
        }

        public void Cadastrar(Pecas pecas)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Add(pecas);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas pecaRetornada = ctx.Pecas.First(x => x.IdPeca == id);
                ctx.Pecas.Remove(pecaRetornada);
                ctx.SaveChanges();
            }
        }

        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
               return ctx.Pecas.ToList();
            }
        }
    }
}
