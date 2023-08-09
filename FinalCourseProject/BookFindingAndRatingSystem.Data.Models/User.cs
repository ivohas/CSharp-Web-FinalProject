using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.UserConst;
namespace BookFindingAndRatingSystem.Data.Models
{
    public class AplicationUser : IdentityUser<Guid>
    {
        public AplicationUser()
        {
            this.Id = Guid.NewGuid();          
        }
        [MaxLength(MaxLengthAbout)]
        public string? About { get; set; }
        [Range(MinBooksToRead,MaxBookToRead)]
        public int? ReadingChallenge { get; set; }

        public string? ImageUrl { get; set; }
        public int? BooksRead { get; set; }
    }
}
