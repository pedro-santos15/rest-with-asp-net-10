
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
        private readonly ILogger<PersonController> _logger;

        public PersonController(IPersonService personService, ILogger<PersonController> logger)
        {
            _personService = personService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Fetching all the people");
            return Ok(_personService.FindAll());

        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            try
            {
                _logger.LogInformation("Fetching person with ID {id}", id);
                return Ok(_personService.FindById(id));
            }
            catch (PersonNotFoundException ex)
            {
                _logger.LogWarning("Person with id {id} not found", id);
                return NotFound(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Person person)
        {
            _logger.LogInformation("Create new person, {person}", person);
            var createdPerson = _personService.Create(person);
            if (createdPerson == null) return BadRequest();
            return Ok(createdPerson);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Person person)
        {
            try
            {
                _logger.LogInformation("Updating person with ID {person.Id}", person.Id);
                var createdPerson = _personService.Update(person);
                _logger.LogInformation("Person successfully updated: {person.Id}", person.Id);
                return Ok(createdPerson);
                
            }
            catch (PersonNotFoundException ex)
            {
                _logger.LogWarning("Person with id {id} not found", person.Id);
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                _logger.LogInformation("Deleting person with id {id}", id);
                _personService.Delete(id);
                _logger.LogDebug("Person with id {id} deleted successfully", id);
                return NoContent();
            }
            catch (PersonNotFoundException ex)
            {
                _logger.LogWarning("Person with id {id} not found", id);
                return NotFound(ex.Message);

            }
        }
    }
}
