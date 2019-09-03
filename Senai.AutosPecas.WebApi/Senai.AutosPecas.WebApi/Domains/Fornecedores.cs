using System;
using System.Collections.Generic;

namespace Senai.AutosPecas.WebApi.Domains
{
    public partial class Fornecedores
    {
        public int IdFonercedor { get; set; }
        public int? Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdPecas { get; set; }

        public Pecas IdPecasNavigation { get; set; }
        public Usuarios IdUsuarioNavigation { get; set; }
    }
}
