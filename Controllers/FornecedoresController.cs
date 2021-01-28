using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using supermercado.Data;
using supermercado.DTO;
using supermercado.Models;

namespace supermercado.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly ApplicationDbContext database;
        public FornecedoresController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Salvar(FornecedorDTO fornecedortemporario)
        {
            if(ModelState.IsValid)
            {
                Fornecedor fornecedor = new Fornecedor();
                fornecedor.Nome = fornecedortemporario.Nome;
                fornecedor.Email = fornecedortemporario.Email;
                fornecedor.Telefone = fornecedortemporario.Telefone;
                fornecedor.Status = true;
                database.Fornecedores.Add(fornecedor);
                database.SaveChanges();
                return RedirectToAction("Fornecedores", "Gestao");
            }
            else{
                return View("../Gestao/NovoFornecedor");
            }
            //return Content("oi");
        }

        [HttpPost]
        public IActionResult Atualizar(FornecedorDTO fornecedortemporario)
        {
            if(ModelState.IsValid)
            {
                var fornecedor = database.Fornecedores.First(forne => forne.Id == fornecedortemporario.Id);
                fornecedor.Nome = fornecedortemporario.Nome;
                fornecedor.Email = fornecedortemporario.Email;
                fornecedor.Telefone = fornecedortemporario.Telefone;
                database.SaveChanges();
                return RedirectToAction("Fornecedores", "Gestao");
            }
            else{
                return View("../Gestao/EditarFornecedor");
            }
        }

        [HttpPost]
        public IActionResult Deletar(int id)
        {
            if(id > 0)
            {
                var fornecedor = database.Fornecedores.First(forne => forne.Id == id);
                fornecedor.Status = false;
                database.SaveChanges();
            }
             return RedirectToAction("Fornecedores", "Gestao");
        }
    }
}