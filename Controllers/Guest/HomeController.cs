using la_mia_pizzeria_static.Context;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers.Guest
{
    public class HomeController : Controller
    {
        readonly Restaurant _db = new();

        public IActionResult Index()
        {

            return View("Home");
        }

        public IActionResult Menu()
        {
            List<Pizza> pizzaList = _db.ListaPizze.Include("Category").Include("Ingredients").OrderBy(p => p.PizzaId).ToList();

            return View(pizzaList);
        }
    }
    
}
