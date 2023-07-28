using System.ComponentModel.DataAnnotations;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.BookConst;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.AuthorConst;
namespace BookFindingAndRatingSystem.Web.ViewModels.Book
{
    public class EditBookViewModel
    {
       
        public string Id { get; set; } = null!;

        [StringLength(BookTitleMaxLeght,MinimumLength = BookTitleMinLenght, ErrorMessage = "Title lenght should be between 5 and 100 characters!")]
        public string Title { get; set; } = null!;
        [StringLength(BookDescriptionMaxLenght, MinimumLength = BookDescriptionMinLenght, ErrorMessage = "Description should be between 50 and 1000 characters!")]
        public string Description { get; set; } = null!;
        [Range(BookMinPages,BookMaxPages,ErrorMessage = "Pages should be between 20 and 2000!")]
        public short Pages { get; set; }

        public string ImageUrl { get; set; } = null!;
        [Range(BookPriceMin, BookPriceMax , ErrorMessage = "Price should be between 1 and 30 800 000 euros!")]
        public float Price { get; set; }
        public int AutorId { get; set; }
        [Range(MinSoldCopies, MaxSoldCopies, ErrorMessage = "Sold copies must be between q nad 300 milions!")]
        public int SoldCopies { get; set; }
    }
}
