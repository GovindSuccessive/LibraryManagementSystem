using LibraryMvc.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryMvc.Configuration
{
    public class PersonConfig:IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.Property(x => x.PersonId).ValueGeneratedOnAdd();
            builder.HasMany(x => x.Books)
                .WithOne(x => x.Person)
                .HasForeignKey(x => x.BookPersonId)
                .HasPrincipalKey(x => x.PersonId);
        }
    }
}
