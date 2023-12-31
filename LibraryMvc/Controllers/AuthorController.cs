using LibraryMvc.Data;
using LibraryMvc.Models;
using LibraryMvc.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryMvc.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryDbContext _libraryDbContext;

        public AuthorController(LibraryDbContext libraryDbContext)
        {
            _libraryDbContext = libraryDbContext;
        }
        [HttpGet]
       
        public async Task<List<Author>> Index()
        {
            return await _libraryDbContext.Author.ToListAsync();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddAuthorDto addAuthorDto)
        {
            if(addAuthorDto != null)
            {
                var author = new Author()
                {
                    AuthorName = addAuthorDto.AuthorName,
                    AuthorEmail = addAuthorDto.AuthorEmail,
                    Books = addAuthorDto.Books
                };
               await _libraryDbContext.Author.AddAsync(author);
               await _libraryDbContext.SaveChangesAsync();
               return RedirectToAction("Index");
            }
            return View();
        }
    }
}
