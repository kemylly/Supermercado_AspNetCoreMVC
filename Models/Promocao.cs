namespace supermercado.Models
{
    public class Promocao
    {
        public int Id {get; set;}
        public string Nome {get; set;}
        //relacionamento entre um produto e uma promocao
        public Produto Produto {get; set;}
        public float Porcentagem {get; set;}
        public bool Status {get; set;}
    }
}