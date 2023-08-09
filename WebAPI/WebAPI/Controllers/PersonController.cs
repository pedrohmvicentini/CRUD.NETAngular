using Microsoft.AspNetCore.Mvc;
using WebAPI.Interfaces;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Person>>> GetPeople()
        {
            return Ok(await _personService.GetAll());
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<Person>> Detail(int id)
        {
            return Ok(await _personService.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<ActionResult<List<Person>>> CreatePerson(Person person)
        {
            return Ok(await _personService.CreatePerson(person));
        }

        [HttpPut]
        public async Task<ActionResult<List<Person>>> UpdatePerson(Person person)
        {
            return Ok(await _personService.UpdatePerson(person));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Person>>> DeletePerson(int id)
        {
            return Ok(await _personService.DeletePerson(id));
        }
    }
}
