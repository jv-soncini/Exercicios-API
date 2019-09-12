using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuariosRepository
    {
        public void Cadastrar(Usuarios usuarios)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuarios.Add(usuarios);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public Usuarios Login(LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
            }
        }
    }
}
