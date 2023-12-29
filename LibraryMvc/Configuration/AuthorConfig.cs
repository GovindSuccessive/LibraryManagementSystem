using LibraryMvc.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryMvc.Configuration
{
    public class AuthorConfig:IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.Property(x=>x.AuthorId).ValueGeneratedOnAdd().IsUnicode(true);
            builder.HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.BookAuthorId)
                .HasPrincipalKey(x => x.AuthorId);
        }
    }
}
