using Microsoft.AspNetCore.Identity;
namespace BookFindingAndRatingSystem.Data.Models
{
    public class AplicationUser : IdentityUser<Guid>
    {
        public AplicationUser()
        {
            this.Id = Guid.NewGuid();
           
        }
    }
}
