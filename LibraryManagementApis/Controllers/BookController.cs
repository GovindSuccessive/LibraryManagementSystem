using LibraryMvc.Data;
using LibraryMvc.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementApis.Controllers
{
    [Route("api/Book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly LibraryDbContext _libraryDbContext;

        public BookController(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Books>> GetBooksList()
        {
            return await _libraryDbContext.Books.ToListAsync();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Books>> AddBooks(Books books)
        {
            if (books == null)
            {

                return BadRequest("Books is Null");
            }
            else
            {
                var bks = new Books()
                {
                   BookTitle=books.BookTitle,
                   BookPrice=books.BookPrice,
                   BookAuthorId=books.BookAuthorId,
                   BookPersonId=books.BookPersonId,
                   //Author=books.Author,
                   //Person=books.Person,
                };
                await _libraryDbContext.Books.AddAsync(bks);
                await _libraryDbContext.SaveChangesAsync();
                return Ok("Book Successfully Added");
            }
        }
    }
}
