using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Web.Data;

namespace BookFindingAndRatingSystem.Services.Tests
{
    public class DatabaseSeeder
    {
        internal static Autor author;
        internal static Autor author2;
        public static void SeedDatabase(BooksDbContext dbContext)
        {
            author = new Autor()
            {
                Id = 1,
                FirstName = "George",
                LastName = "Orwell",
                ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/7/7e/George_Orwell_press_photo.jpg",
                BirthDate = DateTime.Parse("1903-06-25 00:00:00.0000000")
            };
            dbContext.Autors.Add(author);
            author2 = new Autor()
            {
                Id=2,
                FirstName = "F. Scott",
                LastName = "Fitzgerald",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSA1o23Uj2ZRQPJye6056UwvfsgxCcoU2fWwQ&usqp=CAU",
                BirthDate = DateTime.Parse("1896-09-24 00:00:00.0000000")

            };
            dbContext.Autors.Add(author2);
        }
    }
}
