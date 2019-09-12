using System;
using System.Collections.Generic;

namespace Senai.AutoPecas.WebApi.Domains
{
    public partial class Pecas
    {
        public int IdPeca { get; set; }
        public string CodigoPeca { get; set; }
        public string Descricao { get; set; }
        public string Peso { get; set; }
        public string PrecoDeCusto { get; set; }
        public int? IdFornecedores { get; set; }

        public Fornecedores IdFornecedoresNavigation { get; set; }
    }
}
