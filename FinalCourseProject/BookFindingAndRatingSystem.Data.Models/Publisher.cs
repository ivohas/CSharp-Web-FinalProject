using System.ComponentModel.DataAnnotations;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.PublisherConst;
namespace BookFindingAndRatingSystem.Data.Models
{
    public class Publisher
    {
        public Publisher()
        {
            this.Books = new HashSet<Book>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(PublisherNameMaxLenght)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Book> Books { get; set; }
    }
}
