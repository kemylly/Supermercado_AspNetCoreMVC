using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using supermercado.Models;

namespace supermercado.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //entedidade e nome da tabela
        public DbSet<Categoria> Categorias {get; set;}
        public DbSet<Fornecedor> Fornecedores {get; set;}
        public DbSet<Produto> Produtos {get; set;}
        public DbSet<Promocao> Promocoes {get; set;}
        public DbSet<Estoque> Estoques {get; set;}
        public DbSet<Saida> Saidas {get; set;}
        public DbSet<Venda> Vendas {get; set;}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
