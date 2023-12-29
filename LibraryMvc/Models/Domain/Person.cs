using System.ComponentModel.DataAnnotations;

namespace LibraryMvc.Models.Domain
{
    public class Person
    {
        [Key]
        public int PersonId { get; set; }

        public string PersonName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public virtual ICollection<Books> ?Books { get; set; }
    }
}
