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
            this.Books = new HashSet<Book>();
        }
        public ICollection<Book> Books { get; set; }
    }
}
