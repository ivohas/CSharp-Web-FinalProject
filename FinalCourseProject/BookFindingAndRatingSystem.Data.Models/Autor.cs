using System.ComponentModel.DataAnnotations;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.AuthorConst;
namespace BookFindingAndRatingSystem.Data.Models
{
    public class Autor
    {
        public Autor()
        {
            this.Books = new List<Book>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(FirstNameMaxLength)]
        public string FirstName { get; set; } = null!;
        [Required]
        [MaxLength(LastNameMaxLength)]
        public string LastName { get; set; } = null!;
        [Required]
        public string ImageUrl { get; set; } = null!;
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
