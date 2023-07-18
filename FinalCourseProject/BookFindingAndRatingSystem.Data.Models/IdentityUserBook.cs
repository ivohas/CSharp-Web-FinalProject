using System.ComponentModel.DataAnnotations.Schema;

namespace BookFindingAndRatingSystem.Data.Models
{
    public class IdentityUserBook
    {
        public Guid UserId { get; set; }
        [ForeignKey(nameof(UserId))]
        public AplicationUser User { get; set; } = null!;

        public Guid BookId { get; set; }
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}
