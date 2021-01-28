using System.ComponentModel.DataAnnotations;

namespace supermercado.DTO
{
    public class ProdutoDTO
    {
        [Required]
        public int Id {get; set;}
        [Required(ErrorMessage="Nome do produto é obrigatorio")]
        [StringLength(100,ErrorMessage="Nome do produto tem que menos de 100 caracteries")]
        [MinLength(2,ErrorMessage="O nome do é obrigatrio")]
        public string Nome {get; set;}
        [Required(ErrorMessage="Categoria do produto é obrigatoria")]       
        public int CategoriaID {get; set;}
        [Required(ErrorMessage="Fornecedor do produto é obrigatorio")]
        public int FornecedorID {get; set;}
        [Required(ErrorMessage="Custo do produto é obrigatorio")]
        public float PrecoDeCusto {get; set;}
        [Required(ErrorMessage="Custo do produto é obrigatorio")]
        public float PrecoDeVenda {get; set;}
        [Required(ErrorMessage="Medicao do produto é obrigatorio")]
        [Range(0,2,ErrorMessage="Medicao invalida")]
        public int Medicao {get; set;}
        
    }
}