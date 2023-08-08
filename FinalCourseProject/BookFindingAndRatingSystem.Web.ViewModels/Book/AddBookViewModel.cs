using System.ComponentModel.DataAnnotations;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.BookConst;
namespace BookFindingAndRatingSystem.ViewModels
{
    public class AddBookViewModel
    {
        [Required]
        [StringLength(BookTitleMaxLeght, MinimumLength = BookTitleMinLenght, ErrorMessage = "The title should be between 5 and 100 characters!")]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(BookDescriptionMaxLenght, MinimumLength = BookDescriptionMinLenght, ErrorMessage = "Description should be between 50 and 1000 characters!")]
        public string Description { get; set; } = null!;

        [Required]
        [Range(BookMinPages, BookMaxPages, ErrorMessage = "Please enter a valid page count.")]
        public short Pages { get; set; }

        [Required]
        [Url(ErrorMessage = "Please enter a valid URL for the image.")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(BookPriceMin, BookPriceMax, ErrorMessage = "Please enter a valid price.")]
        public float Price { get; set; }

        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }

        [Display(Name = "Author")]
        public int AuthorId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        
        [Range(MinSoldCopies, MaxSoldCopies, ErrorMessage = "Please enter a valid number.")]
        public int? SoldCopies { get; set; }
    }
}
