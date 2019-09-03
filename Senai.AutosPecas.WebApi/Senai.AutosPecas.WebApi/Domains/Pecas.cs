using System;
using System.Collections.Generic;

namespace Senai.AutosPecas.WebApi.Domains
{
    public partial class Pecas
    {
        public Pecas()
        {
            Fornecedores = new HashSet<Fornecedores>();
        }

        public int IdPeca { get; set; }
        public string CodigoPeca { get; set; }
        public string Descricao { get; set; }
        public string Peso { get; set; }
        public string PrecoDeCusto { get; set; }

        public ICollection<Fornecedores> Fornecedores { get; set; }
    }
}
