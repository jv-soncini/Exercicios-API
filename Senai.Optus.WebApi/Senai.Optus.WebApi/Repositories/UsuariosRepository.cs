using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class UsuariosRepository
    {
        public List<Usuarios> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public void Cadastrar(Usuarios usuarios)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Usuarios.Add(usuarios);
                ctx.SaveChanges();
            }
        }

        public Usuarios BuscarPorEmailESenha (LoginViewModel Login)
        {
            using (OptusContext ctx = new OptusContext())
            {
              return  ctx.Usuarios.FirstOrDefault(x => x.Email == Login.Email && x.Senha == Login.Senha );
            }
        }
    }
}
