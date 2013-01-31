using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karol.Dominio
{
    public class Livro
    {
        [Display(Name = "Código")]
        public int LivroId { get; set; }
        
        [Required]
        public string Nome { get; set; }

        [Display(Name = "Data da Publicação")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataDaPublicacao { get; set; }

        [Display(Name = "Prefácio")]
        public string Prefacio { get; set; }

        [Required]
        public string Autor { get; set; }

        [Required]
        public string Editora { get; set; }

    }
}
