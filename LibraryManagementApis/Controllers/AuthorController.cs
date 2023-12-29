using LibraryMvc.Data;
using LibraryMvc.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public IEnumerable<Author> GetAuthorList()
        {
            var author = _libraryDbContext.Author.ToList();
            return author;
        }


    }
}
