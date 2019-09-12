using Senai.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Repositories
{
    public class CategoriaRepository
    {
        public List<Categorias> Listar()
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.ToList();
            }
        }

        public void Cadastrar(Categorias categorias)
        {
            using (GufosContext ctx = new GufosContext())
            {
                ctx.Categorias.Add(categorias);
                ctx.SaveChanges();
            }
        }

        public Categorias BuscarPorId(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

        public void Deletar(int id)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Categorias categorias = ctx.Categorias.Find(id);

                ctx.Categorias.Remove(categorias);

                ctx.SaveChanges();
            }
        }

        public void Atualizar(Categorias categoria)
        {
            using (GufosContext ctx = new GufosContext())
            {
                Categorias categoriaBuscada = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);

                ctx.Categorias.Update(categoriaBuscada);

                ctx.SaveChanges();
            }
        }
    }
}
