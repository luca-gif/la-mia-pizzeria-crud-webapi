using la_mia_pizzeria_static.Context;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace la_mia_pizzeria_static.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly Restaurant _db = new Restaurant();
        public IActionResult Index()
        {
            List<Message> messages = _db.Messages.ToList();

            return View("Messages", messages);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Erase(int id)
        {

            Message messageToDelete = _db.Messages.Where(p => p.Id == id).FirstOrDefault();

            if (messageToDelete != null)
            {
                _db.Messages.Remove(messageToDelete);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return NotFound("La pizza che stai cercando non è presente");
            }
        }

    }

}
