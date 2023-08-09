using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.RatingConst;
namespace BookFindingAndRatingSystem.Data.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        [Range(MinRating,MaxRating)]
        public int Rate { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AplicationUser User { get; set; } = null!;
        [Required]
        public Guid BookId { get; set; }
        public Book Book { get; set; } = null!;
    }
}
