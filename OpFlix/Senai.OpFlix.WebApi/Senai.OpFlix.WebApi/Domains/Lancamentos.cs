using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Lancamentos
    {
        public int IdLancamento { get; set; }
        public string Titulo { get; set; }
        public string Sipnose { get; set; }
        public TimeSpan? TempoDeDuracao { get; set; }
        public int IdCategoria { get; set; }
        public int? IdPlataforma { get; set; }
        public int IdTipo { get; set; }
        public DateTime DataLancamento { get; set; }
        public int? IdClassificacao { get; set; }
        public string Imagenm { get; set; }

        public Categoria IdCategoriaNavigation { get; set; }
        public Classificacao IdClassificacaoNavigation { get; set; }
        public Plataforma IdPlataformaNavigation { get; set; }
        public TipoLancamento IdTipoNavigation { get; set; }
    }
}
