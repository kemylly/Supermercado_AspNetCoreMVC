namespace supermercado.Models
{
    public class Produto
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        //um produto tem uma categoria - chave estrangeira
        public Categoria Categoria{get; set;}
        public Fornecedor Fornecedor {get; set;}
        public float PrecoDeCusto {get; set;}
        public float PrecoDeVenda {get; set;}
        public int Medicao {get; set;}
        public bool Status {get; set;} //produto ativo ou inativo
    }
}