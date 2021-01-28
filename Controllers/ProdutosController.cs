using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using supermercado.Data;
using supermercado.DTO;
using supermercado.Models;

namespace supermercado.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly ApplicationDbContext database;
        public ProdutosController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(ProdutoDTO produtotemporario)
        {
            if(ModelState.IsValid)
            {
                Produto produto = new Produto();
                produto.Nome = produtotemporario.Nome;
                produto.Categoria = database.Categorias.First(categoria => categoria.Id == produtotemporario.CategoriaID);
                produto.Fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == produtotemporario.FornecedorID);
                produto.PrecoDeCusto = produtotemporario.PrecoDeCusto;
                produto.PrecoDeVenda = produtotemporario.PrecoDeVenda;
                produto.Medicao = produtotemporario.Medicao;
                produto.Status = true;
                database.Produtos.Add(produto);
                database.SaveChanges();
                return RedirectToAction("Produtos", "Gestao");
            }
            else{
                ViewBag.Categorias = database.Categorias.ToList();
                ViewBag.Fornecedores = database.Fornecedores.ToList();
                return View("../Gestao/NovoProduto");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(ProdutoDTO produtotemporario)
        {
            if(ModelState.IsValid)
            {
                var produto = database.Produtos.First(prod => prod.Id == produtotemporario.Id);
                produto.Nome = produtotemporario.Nome;
                produto.Categoria = database.Categorias.First(categoria => categoria.Id == produtotemporario.CategoriaID);
                produto.Fornecedor = database.Fornecedores.First(fornecedor => fornecedor.Id == produtotemporario.FornecedorID);
                produto.PrecoDeCusto = produtotemporario.PrecoDeCusto;
                produto.PrecoDeVenda = produtotemporario.PrecoDeVenda;
                produto.Medicao = produtotemporario.Medicao;
                database.SaveChanges();
                return RedirectToAction("Produtos", "Gestao");
            }
            else{
                return View("../Gestao/EditarProduto");
            }
        }

        public IActionResult Deletar(int id)
        {
            if(id > 0)
            {
                var produto = database.Produtos.First(prod => prod.Id == id);
                produto.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Produtos", "Gestao");
        }
    }
}