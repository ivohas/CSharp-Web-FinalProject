namespace BookFindingAndRatingSystem.Web.ViewModels.Book
{
    public class DetailsBookViewModel : AllBookViewModel
    {
        public string Category { get; set; } = null!;
        public string Publisher { get; set; } = null!;
        public string AutorName { get; set; } = null!;
        public int AutorId { get; set; }
        public int SelledCopies { get; set; }

        public bool AlreadyAddedByThisUser { get; set; }
    }
}
