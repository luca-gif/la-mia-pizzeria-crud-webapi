using la_mia_pizzeria_static.Context;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly Restaurant _db = new Restaurant();

        public IActionResult Get(string? pizzaName)
        {
            List<Pizza> pizzas = new List<Pizza>();

            if (pizzaName != null)
            {
                pizzas = _db.ListaPizze.Include("Category").Include("Ingredients").Where(pizza => pizza.Name.ToLower().Contains(pizzaName.ToLower())).ToList();
            }
            else
            {
                pizzas = _db.ListaPizze.Include("Category").Include("Ingredients").ToList();
            }

            return Ok(pizzas.ToList());
        }

        public IActionResult Detail(int? id)
        {
            Pizza pizza = _db.ListaPizze.Include("Category").Include("Ingredients").Where(pizza => pizza.PizzaId == id).FirstOrDefault();



            return Ok(pizza);
        }

    }
}