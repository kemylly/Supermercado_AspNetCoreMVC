using System.ComponentModel.DataAnnotations;
using System;
using supermercado.Controllers;
using supermercado.Models;

namespace supermercado.DTO
{
    public class FornecedorDTO
    {
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage="Nome de fornecedor é obrigatorio")]
        [StringLength(100,ErrorMessage="Nome de fornecedor muito grade")]
        [MinLength(2, ErrorMessage="Nome de fornecedor muito pequeno")]
        public string Nome {get; set;}
        [Required(ErrorMessage="Email é obrigatorio")]
        [EmailAddress(ErrorMessage="E-mail é invalido")]
        public string Email {get; set;}
        [Required(ErrorMessage="Telefone de fornecedor é obrigatorio")]
        [Phone(ErrorMessage="Numero de telefone invalido")]
        public string Telefone {get; set;}

        
    }
}