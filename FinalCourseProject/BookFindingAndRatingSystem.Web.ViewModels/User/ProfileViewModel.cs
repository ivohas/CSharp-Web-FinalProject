using BookFindingAndRatingSystem.Web.ViewModels.Book;
using System.ComponentModel.DataAnnotations;

namespace BookFindingAndRatingSystem.ViewModels
{
    public class ProfileViewModel
    {
        public ProfileViewModel()
        {
            this.BooksWantToRead = new HashSet<AllBookViewModel>();
            this.ReadBooks = new HashSet<AllBookViewModel>();
        }
        public Guid Id { get; set; }
        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        public string Email { get; set; } = null!;
        public string? PhoneNumber { get; set; }

        public string? About { get; set; }
      

        public ICollection<AllBookViewModel> BooksWantToRead { get; set; }

        public int? ReadingChalenge { get; set; }

        public ICollection<AllBookViewModel> ReadBooks { get; set; }
    }
}
