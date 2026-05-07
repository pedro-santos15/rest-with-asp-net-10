
using Microsoft.AspNetCore.Mvc;
using RestWithASPNET10.Exceptions;
using RestWithASPNET10.Model;
using RestWithASPNET10.Services;

namespace RestWithASPNET10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {

        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_personService.FindAll());

        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                return Ok(_personService.FindById(id));
            }
            catch (PersonNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            var createdPerson = _personService.Create(person);
            if (createdPerson == null) return BadRequest();
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            try
            {
                var createdPerson = _personService.Update(person);
                return Ok(createdPerson);

            }
            catch (PersonNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _personService.Delete(id);
                return NoContent();
            }
            catch (PersonNotFoundException ex)
            {
                return NotFound(ex.Message);

            }
        }
    }
}
