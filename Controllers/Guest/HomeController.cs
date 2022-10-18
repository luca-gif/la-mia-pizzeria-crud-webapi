using la_mia_pizzeria_static.Context;
using Microsoft.AspNetCore.Mvc;

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

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Detail(int id)
        {
            ViewData["pizzaId"] = id;

            return View("PizzaDetails");
        }

    }
}
