using LibraryMvc.Configuration;
using LibraryMvc.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace LibraryMvc.Data
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
        {
            
        }
        public LibraryDbContext(DbContextOptions options) : base(options)
        {
        }
        
        public DbSet<Author> Author { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Person> Persons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new PersonConfig());
            base.OnModelCreating(modelBuilder);
        }

    }
}
