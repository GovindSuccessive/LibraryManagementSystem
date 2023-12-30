using LibraryMvc.Data;
using LibraryMvc.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApis.Controllers
{
    [Route("api/Author/")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly LibraryDbContext _libraryDbContext;

        public AuthorController(LibraryDbContext libraryDbContext) {
            _libraryDbContext = libraryDbContext;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Author>> GetAuthorList()
        {
            return await _libraryDbContext.Author.ToListAsync();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Author>> AddAuthor(Author author)
        {
            if (author == null)
            {

                return BadRequest("Author is Null");
            }
            else
            {
                var arth = new Author()
                {
                   AuthorName=author.AuthorName,
                   AuthorEmail=author.AuthorEmail,
                   Books = author.Books,
                };
                await _libraryDbContext.Author.AddAsync(arth);
                await _libraryDbContext.SaveChangesAsync();
                return Ok("Author Successfully Added");
            }
        }


    }
}
