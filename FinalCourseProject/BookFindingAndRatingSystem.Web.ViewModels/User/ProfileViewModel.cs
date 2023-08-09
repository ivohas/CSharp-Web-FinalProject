using BookFindingAndRatingSystem.Web.ViewModels.Book;
using System.ComponentModel.DataAnnotations;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.UserConst;
namespace BookFindingAndRatingSystem.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            this.ReadBooks = new HashSet<AllBookViewModel>();
        }
        public Guid Id { get; set; }
        [StringLength(UserNameMaxLenght, MinimumLength = UserNameMinLenght, ErrorMessage = "The username lenght should be betweem {2} and {1} characters!")]
        public string? UserName { get; set; } 
        [StringLength(UserEmailMaxLength,MinimumLength = UserEmailMinLenght, ErrorMessage = "The email lenght should be between {2} and {1} characters!")]
        public string? Email { get; set; } 
        public string? PhoneNumber { get; set; }
        [StringLength(UserAboutMaxLenght, MinimumLength = UserAboutMinLenght, ErrorMessage = "The about lenght should be between {2} and {1} characters!")]
        public string? About { get; set; }
              
        public int? ReadingChalenge { get; set; }

        public ICollection<AllBookViewModel> ReadBooks { get; set; }
        [Url(ErrorMessage = "Enter valid url!")]
        public string? ImageUrl { get; set; }
        [Range(MinBookRead,MaxBookRead)]
        public int? BookRead { get; set; }

        [Phone]
        public string? PhoneMunber { get; set; }

    }
}
