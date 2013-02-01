using System.ComponentModel.DataAnnotations;

namespace Karol.Dominio
{
    public class Autor
    {
        public int AutorId { get; set; }
        
        [Required]
        [MaxLength(75)]
        public string Nome { get; set; }

        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "O email informado não é valido")]
        [MaxLength(75)]
        public string Email { get; set; }
        
        [Required]
        [MaxLength(500)]
        public string Biografia { get; set; }
    }
}
