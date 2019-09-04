using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
      
        public Usuarios Login(LoginViewModel Login)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.Email == Login.Email && x.Senha == Login.Senha);
            }
        }
    }
}
