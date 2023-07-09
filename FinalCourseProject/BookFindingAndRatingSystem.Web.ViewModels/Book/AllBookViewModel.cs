namespace BookFindingAndRatingSystem.Web.ViewModels.Book
{
    public class AllBookViewModel
    {
        public string Id { get; set; } = null!;

        public string Title { get; set; } = null!;

        public string Description { get; set; } = null!;

        public short Pages { get; set; }

        public string ImageUrl { get; set; } = null!;

        public float Price { get; set; }

    }
}
