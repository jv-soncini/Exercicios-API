using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public void Atualizar(Categoria categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Categoria CategoriaBuscada = ctx.Categoria.FirstOrDefault(x => x.IdCategoria == categoria.IdCategoria);
                ctx.Categoria.Update(CategoriaBuscada);
                ctx.SaveChanges();
            }
        }

        public void Cadastrar(Categoria categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Categoria.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public List<Categoria> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categoria.ToList();
            }
        }
    }
}
