using System.ComponentModel.DataAnnotations;

namespace BookFindingAndRatingSystem.ViewModels
{
    public class AddBookViewModel
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Range(1, short.MaxValue, ErrorMessage = "Please enter a valid page count.")]
        public short Pages { get; set; }

        [Required]
        [Url(ErrorMessage = "Please enter a valid URL for the image.")]
        public string ImageUrl { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a valid price.")]
        public float Price { get; set; }

        [Display(Name = "Publisher")]
        public int PublisherId { get; set; }

        [Display(Name = "Author")]
        public int AuthorId { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number.")]
        public int SelledCopies { get; set; }
    }
}
