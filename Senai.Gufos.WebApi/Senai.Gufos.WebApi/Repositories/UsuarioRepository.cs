using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarUsuariosEsenha (LoginViewModel login)
        {
            using (GufosContext ctx = new GufosContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email  && x.Senha == login.Senha );
            }
        }
    }
}
