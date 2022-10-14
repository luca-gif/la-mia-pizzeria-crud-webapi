using la_mia_pizzeria_static.Context;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        readonly Restaurant _db = new Restaurant();

        public IActionResult Get()
        {
            List<Pizza> pizzas = _db.ListaPizze.ToList();

            return Ok(pizzas);
        }
    }
}
