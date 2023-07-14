using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.BookConst;
namespace BookFindingAndRatingSystem.Data.Models
{
    public class Book
    {
        public Book()
        {
            this.Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(BookTitleMaxLeght)]
        public string Title { get; set; } = null!;
        [Required]
        [MaxLength(BookDescriptionMaxLenght)]
        public string Description { get; set; } = null!;
        [Required]
        [Range(BookMinPages, BookMaxPages)]
        public short Pages { get; set; }
        [Required]
        public string ImageUrl { get; set; } = null!;
        //May make it euros and float-point
        [Required]
        [Range(BookPriceMin,BookPriceMax)]
        public float Price { get; set; }

        public int PublishersId { get; set; }
        [ForeignKey(nameof(PublishersId))]
        public Publisher Publisher { get; set; } = null!;

        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;
        [Required]
        public int SelledCopies { get; set; }
    }
}