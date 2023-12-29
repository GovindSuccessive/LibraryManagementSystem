using LibraryMvc.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryMvc.Configuration
{
    public class BookConfig:IEntityTypeConfiguration<Books>
    {
        public void Configure(EntityTypeBuilder<Books> builder) {

            builder.ToTable("Books");
            builder.Property(x => x.BookId).ValueGeneratedOnAdd();
            builder.HasOne(x => x.Author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.BookAuthorId)
                .HasPrincipalKey(x=>x.AuthorId);

            builder.HasOne(x => x.Person)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.BookPersonId)
                .HasPrincipalKey(x => x.PersonId);
        }
    }
}
