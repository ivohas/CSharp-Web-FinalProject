using BookFindingAndRatingSystem.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.RatingConst;

namespace BookFindingAndRatingSystem.Web.ViewModels.Rating
{
    public class RatingViewModel
    {
        [Range(MinRating, MaxRating)]
        public int Rate { get; set; }
        [Required]
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
