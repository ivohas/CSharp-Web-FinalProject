using System.ComponentModel.DataAnnotations;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.AuthorConst;
namespace BookFindingAndRatingSystem.ViewModels
{
    public class AuthorViewModel
    {
        [Required]
        [StringLength(FirstNameMaxLength, MinimumLength = FirstNameMinLength, ErrorMessage = "First Name is not right")]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Display(Name = "LastName")]
        [StringLength(LastNameMaxLength, MinimumLength = LastNameMinLength, ErrorMessage = "Last Name is not right")]
        public string LastName { get; set; } = null!;

        [Required]
        [Display(Name = "Image")]
        [Url(ErrorMessage = "Please enter a valid URL for the image.")]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Display(Name = "BirthDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime BirthDate { get; set; }
    }
}
