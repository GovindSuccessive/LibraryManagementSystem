using LibraryMvc.Data;
using LibraryMvc.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApis.Controllers
{
    [Route("api/Person")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly LibraryDbContext _libraryDbContext;

        public PersonController(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Person>> GetPersons()
        {
            return await _libraryDbContext.Persons.ToListAsync();   
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Person>> AddPerons(Person person)
        {
            if(person == null) {

                return BadRequest("Person is Null");
            }
            else
            {
                var prs = new Person()
                {
                    PersonName = person.PersonName,
                    PhoneNumber = person.PhoneNumber,
                    Address = person.Address,
                    Books = person.Books,
                };
                await _libraryDbContext.Persons.AddAsync(prs);
                await _libraryDbContext.SaveChangesAsync();
                return Ok("Person Successfully Added");
            }
        }

    }
}
