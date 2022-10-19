using la_mia_pizzeria_static.Context;
using la_mia_pizzeria_static.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace la_mia_pizzeria_static.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly Restaurant _db = new Restaurant();

        // GET: api/<MessagesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<MessagesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<MessagesController>
        [HttpPost]
        public IActionResult SendMessage([FromBody] Message message)
        {

            _db.Messages.Add(message);
            _db.SaveChanges();

            return Ok(new { message = "sended" });
        }

        // PUT api/<MessagesController>/5

        [HttpPut("{id}")]
        public IActionResult UpdateMessage(int id, [FromBody] Message message)
        {

            if (!ModelState.IsValid)
            {
                return UnprocessableEntity(ModelState);
            }

            else
            {
                Message msgToUpdate = _db.Messages.Where(msg => msg.Id == id).FirstOrDefault();

                if (msgToUpdate != null)
                {
                    _db.Messages.Update(msgToUpdate);
                    _db.SaveChanges();

                    return Ok(msgToUpdate);
                }
                else
                {
                    // se non è stato trovato resituiamo che non esiste
                    return NotFound();
                }
            }

        }


        // DELETE api/<MessagesController>/5

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
