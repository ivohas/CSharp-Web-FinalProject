using System.ComponentModel.DataAnnotations;
using static BookFindingAndRatingSystem.Common.EntityValidationConstants.PublisherConst;
namespace BookFindingAndRatingSystem.Web.ViewModels.Publisher
{
    public class AddPublisherViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(PublisherNameMaxLenght, MinimumLength = PublisherNameMinLenght, ErrorMessage = "The lenght should be between {2} and {1} characters!")]
        public string Name { get; set; } = null!;
    }
}
