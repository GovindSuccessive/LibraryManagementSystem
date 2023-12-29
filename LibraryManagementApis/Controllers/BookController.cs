using LibraryMvc.Data;
using LibraryMvc.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Books> GetBooksList()
        {
            var books = _libraryDbContext.Books.ToList();
            return books;
        }
    }
}
