using BookFindingAndRatingSystem.Web.ViewModels.Book;

namespace BookFindingAndRatingSystem.Web.ViewModels.Autor
{
    public class AllAutorViewModel
    {
        public int Id { get; set; }
       
        public string FirstName { get; set; } = null!;
      
        public string LastName { get; set; } = null!;
       
        public string ImageUrl { get; set; } = null!;

        public DateTime BirthDate { get; set; }
        public List<AllBookViewModel> Books { get; set; }

    }
}
