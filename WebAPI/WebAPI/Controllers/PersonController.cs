using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPeople()
        {
            return Ok(await _context.Person.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> CreatePerson(Person person)
        {
            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return Ok(await _context.Person.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person person)
        {
            var dbPerson = await _context.Person.FindAsync(person.Id);
            if (dbPerson == null)
                return BadRequest("Contact not found.");

            dbPerson.FirstName = person.FirstName?.Trim();
            dbPerson.LastName = person.LastName?.Trim();

            await _context.SaveChangesAsync();

            return Ok(await _context.Person.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            var dbPerson = await _context.Person.FindAsync(id);
            if (dbPerson == null)
                return BadRequest("Contact not found.");

            _context.Person.Remove(dbPerson);
            await _context.SaveChangesAsync();

            return Ok(await _context.Person.ToListAsync());
        }
    }
}
