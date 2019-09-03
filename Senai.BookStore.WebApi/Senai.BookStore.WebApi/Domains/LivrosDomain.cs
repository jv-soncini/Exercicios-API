using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.BookStore.WebApi.Domains
{
    public class LivrosDomain
    {
        public int IdLivro { get; set; }
        public string Titulo { get; set; }
        public GenerosDomain Genero { get; set; }
        public int GeneroId { get; set; }
        public AutoresDomain Autor { get; set; }
        public int AutoresId { get; set; }
    }
}
