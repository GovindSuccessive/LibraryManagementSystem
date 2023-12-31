using LibraryMvc.Models.Domain;

namespace LibraryMvc.Models
{
    public class AddAuthorDto
    {
        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; }

        public virtual ICollection<Books>? Books { get; set; }
    }
}
