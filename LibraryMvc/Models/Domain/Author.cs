using System.ComponentModel.DataAnnotations;

namespace LibraryMvc.Models.Domain
{
    public class Author
    {
        [Key]
        public int AuthorId { get; set; }

        public string AuthorName { get; set; }

        public string AuthorEmail { get; set; }

        public virtual ICollection<Books> ?Books { get; set; }
    }
}
