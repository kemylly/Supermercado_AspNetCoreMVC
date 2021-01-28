using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using supermercado.Data;
using supermercado.DTO;
using supermercado.Models;

namespace supermercado.Controllers
{
    public class PromocoesController : Controller
    {
        private readonly ApplicationDbContext database;
        public PromocoesController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(PromocaoDTO promocaotemporaria)
        {
            if(ModelState.IsValid)
            {
                Promocao promocao = new Promocao();
                promocao.Nome = promocaotemporaria.Nome;
                promocao.Produto = database.Produtos.First(prod => prod.Id == promocaotemporaria.ProdutoID);
                promocao.Porcentagem = promocaotemporaria.Porcentagem;
                promocao.Status = true;
                database.Promocoes.Add(promocao);
                database.SaveChanges();
                return RedirectToAction("Promocoes", "Gestao");
            }
            else
            {
                 ViewBag.Produtos = database.Produtos.ToList();
                return View("../Gestao/NovaPromocao");
            }
        }

        [HttpPost]
        public IActionResult Atualizar(PromocaoDTO promocaoTemporaria)
        {
            if(ModelState.IsValid)
            {
                var promocao = database.Promocoes.First(p => p.Id == promocaoTemporaria.Id);
                promocao.Nome = promocaoTemporaria.Nome;
                promocao.Porcentagem = promocaoTemporaria.Porcentagem;
                promocao.Produto = database.Produtos.First(prod => prod.Id == promocaoTemporaria.ProdutoID);
                database.SaveChanges();
                return RedirectToAction("Promocoes", "Gestao");
            }
            else{
                return RedirectToAction("Promocoes", "Gestao");
            }
        }

        public IActionResult Deletar(int id)
        {
            if(id > 0)
            {
                var promocao = database.Promocoes.First(p => p.Id == id);
                promocao.Status = false;
                database.SaveChanges();
            }
            return RedirectToAction("Promocoes", "Gestao");
        }
    }
}