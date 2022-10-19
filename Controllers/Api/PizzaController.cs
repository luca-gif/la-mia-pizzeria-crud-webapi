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
                pizzas = _db.ListaPizze.Include("Category").Include("Ingredients").OrderBy(p => p.Price).Where(pizza => pizza.Name.ToLower().Contains(pizzaName.ToLower())).ToList();
            }
            else
            {
                pizzas = _db.ListaPizze.Include("Category").Include("Ingredients").OrderBy(p => p.Price).ToList();
            }

            return Ok(pizzas.ToList());
        }


        public IActionResult Dettaglio(int? id)
        {
            Pizza pizza = _db.ListaPizze.Include("Category").Include("Ingredients").Where(pizza => pizza.PizzaId == id).FirstOrDefault();

            return Ok(pizza);
        }


        [HttpPut("{id}")]
        public IActionResult Update(int? id, Pizza data)
        {
            Pizza PizzaToUpdate = _db.ListaPizze.Where(p => p.PizzaId == id).FirstOrDefault();

            if (PizzaToUpdate != null)
            {
                PizzaToUpdate.Price = data.Price;
                PizzaToUpdate.Name = data.Name;
                PizzaToUpdate.Image = data.Image;
                PizzaToUpdate.Description = data.Description;
                PizzaToUpdate.CategoryId = data.CategoryId;
                //PizzaToUpdate.Ingredients = _db.Ingredients.Where(ingredient => data.Ingredients.Contains(data)).ToList();

                _db.SaveChanges();

                return Ok(PizzaToUpdate);
            }
            else
            {
                return NotFound(new { Message = "Pizza non trovata", Id = id });
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int? id)
        {
            Pizza PizzaToDelete = _db.ListaPizze.Where(p => p.PizzaId == id).FirstOrDefault();

            if (PizzaToDelete != null)
            {
                try
                {
                    _db.ListaPizze.Remove(PizzaToDelete);
                    _db.SaveChanges();

                }
                catch (Exception ex)
                {

                }

                return Ok(new { Message = "Pizza eliminata correttamente", Id = id });

            }

            else
            {
                return NotFound(new { Message = "Pizza non trovata", Id = id });
            }
        }

    }
}