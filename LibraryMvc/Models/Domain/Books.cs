using System.ComponentModel.DataAnnotations;

namespace LibraryMvc.Models.Domain
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public int BookPrice { get; set; }

        public int BookPersonId { get; set; }

        public virtual Person ?Person { get; set; }

        public int BookAuthorId { get; set; }

        public virtual Author ?Author { get; set; }
    }
}
