using GoodTrip.Data;
using GoodTrip.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace GoodTrip.Controllers
{
    
    public class ComprarController : Controller
    {
        [HttpGet]
        
        public IActionResult Index()
        {
            var dbContext = new Context();

            ViewData["Cliente"] = dbContext.clientes.Where(p => p.Id_cliente > 0).ToList();
            ViewData["Passagem"] = dbContext.passagens.Where(p => p.Id_pass > 0).ToList();

            return View();
        }

        [HttpPost]
        
        public IActionResult Incluir(Passagem passagem, Cliente cliente)
        {
            var dbcontext = new Context();
            dbcontext.Add(passagem);
            dbcontext.Add(cliente); 
            dbcontext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
