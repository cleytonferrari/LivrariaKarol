using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karol.Dominio
{
    public class Livro
    {
        public int LivroId { get; set; }
        public string Nome { get; set; }
        public DateTime DataDaPublicacao { get; set; }
        public string Prefacio { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }

    }
}
