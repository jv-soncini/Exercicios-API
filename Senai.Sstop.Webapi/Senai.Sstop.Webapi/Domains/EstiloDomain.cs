using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.Webapi.Domains
{
    public class EstiloDomain
    {
        public int IdEstilo { get; set; }
        [Required(ErrorMessage = "Precisa por o name né")]
        public string Nome { get; set; }
    }
}
