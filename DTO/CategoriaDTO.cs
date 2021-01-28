using System.ComponentModel.DataAnnotations;

namespace supermercado.DTO
{
    public class CategoriaDTO 
    {
        //apenas transporta dados da entidade categoria e do formulario
        [Required]
        public int Id {get; set;}
        [Required(ErrorMessage="Nome de categoria é obrigatorio")]
        [StringLength(100,ErrorMessage="Nome de categoria muito grade")]
        [MinLength(2, ErrorMessage="Nome de categoria muito pequeno")]
        public string Nome {get; set;}
        
    }
}