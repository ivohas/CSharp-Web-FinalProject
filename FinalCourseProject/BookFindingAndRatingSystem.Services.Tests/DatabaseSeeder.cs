using BookFindingAndRatingSystem.Data.Models;
using BookFindingAndRatingSystem.Web.Data;

namespace BookFindingAndRatingSystem.Services.Tests
{
    public class DatabaseSeeder
    {
        public static Autor author;
        public static Autor author2;
        public static Book book;
        public static Book book2;
        public static void SeedDatabase(BooksDbContext dbContext)
        {
            dbContext.ChangeTracker.Clear();
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

            //Books
            
            book = new Book
            {
                Title = "The Great Gatsby",
                Description = "A novel by F. Scott Fitzgerald",
                Pages = 180,
                Price = 7.99f,
                ImageUrl = "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750",
                PublishersId = 4,
                CategoryId = 8,
                AutorId = 3,
                SelledCopies = 25_000_000
            };
            dbContext.Books.Add(book);
            book2 = new Book
            {
                Title = "1984",
                Description = "A dystopian novel by George Orwell",
                Pages = 328,
                ImageUrl = "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg",
                Price = 9.99f,
                PublishersId = 2,
                CategoryId = 8,
                AutorId = 1,
                SelledCopies = 30_000_000
            };
            dbContext.Books.Add(book2);
        }
    }
}
