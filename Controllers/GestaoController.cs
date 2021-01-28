using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using supermercado.Data;
using supermercado.DTO;

namespace supermercado.Controllers
{
    public class GestaoController : Controller
    {
        private readonly ApplicationDbContext database;
        public GestaoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Categorias()
        {
            var categorias = database.Categorias.Where(cat => cat.Status == true).ToList();

            return View(categorias); //listagem das categorias
        }

        public IActionResult NovaCategoria()
        {
            return View(); //formularios de categorias
        }

        public IActionResult EditarCategoria(int id)
        {
            var categoria = database.Categorias.First(cat => cat.Id == id);
            CategoriaDTO categoriaView = new CategoriaDTO();
            categoriaView.Id = categoria.Id;
            categoriaView.Nome = categoria.Nome;
            return View(categoriaView);
        }

        public IActionResult Fornecedores()
        {
            var fornecedores = database.Fornecedores.Where(forne => forne.Status == true).ToList();
            return View(fornecedores); //listagem de fornecedor
        }

        public IActionResult NovoFornecedor()
        {
            return View(); //formularios de fornecedor
        }

        public IActionResult EditarFornecedor(int id)
        {
            var fornecedor = database.Fornecedores.First(forne => forne.Id ==id);
            FornecedorDTO fornecedorView = new FornecedorDTO();
            fornecedorView.Id = fornecedor.Id;
            fornecedorView.Nome = fornecedor.Nome;
            fornecedorView.Email = fornecedor.Email;
            fornecedorView.Telefone = fornecedor.Telefone;
            return View(fornecedorView);
        }

        public IActionResult Produtos()
        {
            var produtos = database.Produtos.Include(p => p.Categoria).Include(p => p.Fornecedor).Where(p => p.Status == true).ToList();
            return View(produtos); //listagem de produto com inlude que a consulta com uma tabela de relacionamento
        }

        public IActionResult NovoProduto()
        {
            //ViewBag.Nomequalquer
            ViewBag.Categorias = database.Categorias.ToList();
            ViewBag.Fornecedores = database.Fornecedores.ToList();
            return View(); //formularios de produtp
        }

        public IActionResult EditarProduto(int id)
        {
            var produto = database.Produtos.Include(p => p.Categoria).Include(p => p.Fornecedor).First(p => p.Id == id);
            ProdutoDTO produtoView = new ProdutoDTO();
            produtoView.Id = produto.Id;
            produtoView.Nome = produto.Nome;
            produtoView.PrecoDeCusto = produto.PrecoDeCusto;
            produtoView.PrecoDeVenda = produto.PrecoDeVenda;
            produtoView.CategoriaID = produto.Id;
            produtoView.FornecedorID = produto.Id;
            produtoView.Medicao = produto.Medicao;
            ViewBag.Categorias = database.Categorias.ToList();
            ViewBag.Fornecedores = database.Fornecedores.ToList();
            return View(produtoView);
        }

        public IActionResult Promocoes()
        {
            //buscar promocoes no banco e dados
            var promocoes = database.Promocoes.Include(p => p.Produto).Where(i => i.Status == true).ToList();
            return View(promocoes);
        }

        public IActionResult NovaPromocao()
        {
            ViewBag.Produtos = database.Produtos.ToList();
            return View();
        }

        public IActionResult EditarPromocao(int id)
        {
            var promocao = database.Promocoes.Include(p => p.Produto).First(p => p.Id == id);
            PromocaoDTO promo = new PromocaoDTO();
            promo.Id = promocao.Id;
            promo.Nome = promocao.Nome;
            promo.Porcentagem = promocao.Porcentagem;
            promo.ProdutoID = promocao.Produto.Id;
            ViewBag.Produtos = database.Produtos.ToList();
            return View(promo);
        }
    }
}