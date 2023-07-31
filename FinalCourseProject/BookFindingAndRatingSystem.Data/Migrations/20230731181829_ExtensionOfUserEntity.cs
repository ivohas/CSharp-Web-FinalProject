using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookFindingAndRatingSystem.Data.Migrations
{
    public partial class ExtensionOfUserEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2640fdd7-5096-4209-a7e1-e312eb102c40"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9b49dc1a-3143-43af-8de4-b4ff8cd4b74b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("b2520697-283d-44f3-8cd2-cdf0dffa5bcc"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d0c88763-02af-4e4e-8e27-8e42afaca348"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("dbcc38f6-57b2-4ccd-a2ec-ac5b9920829f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f449ff24-b7d8-4035-9d4a-01991cd2d677"));

            migrationBuilder.AddColumn<string>(
                name: "About",
                table: "AspNetUsers",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BooksToRead",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "SelledCopies", "Title" },
                values: new object[,]
                {
                    { new Guid("35881639-299a-4bfb-af47-a6e81cab80db"), 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, 100000000, "The Hobbit" },
                    { new Guid("488c22f4-35b3-467d-996d-450a6ccdc45a"), 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, 30000000, "1984" },
                    { new Guid("79763574-b8f6-49b5-aa9b-f430cd995467"), 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, 25000000, "The Great Gatsby" },
                    { new Guid("7d4b443b-bbe4-43b8-ba8b-5b4950cf4d7e"), 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, 65000000, "The Catcher in the Rye" },
                    { new Guid("a9d2fe05-591b-447e-8add-b3784f4b42fb"), 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, 40000000, "To Kill a Mockingbird" },
                    { new Guid("f603cdd3-bf3c-41a5-baa0-83022450cb32"), 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, 120000000, "Harry Potter and the Philosopher's Stone" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("35881639-299a-4bfb-af47-a6e81cab80db"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("488c22f4-35b3-467d-996d-450a6ccdc45a"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("79763574-b8f6-49b5-aa9b-f430cd995467"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7d4b443b-bbe4-43b8-ba8b-5b4950cf4d7e"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a9d2fe05-591b-447e-8add-b3784f4b42fb"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f603cdd3-bf3c-41a5-baa0-83022450cb32"));

            migrationBuilder.DropColumn(
                name: "About",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "BooksToRead",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "SelledCopies", "Title" },
                values: new object[,]
                {
                    { new Guid("2640fdd7-5096-4209-a7e1-e312eb102c40"), 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, 65000000, "The Catcher in the Rye" },
                    { new Guid("9b49dc1a-3143-43af-8de4-b4ff8cd4b74b"), 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, 100000000, "The Hobbit" },
                    { new Guid("b2520697-283d-44f3-8cd2-cdf0dffa5bcc"), 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, 120000000, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("d0c88763-02af-4e4e-8e27-8e42afaca348"), 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, 40000000, "To Kill a Mockingbird" },
                    { new Guid("dbcc38f6-57b2-4ccd-a2ec-ac5b9920829f"), 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, 25000000, "The Great Gatsby" },
                    { new Guid("f449ff24-b7d8-4035-9d4a-01991cd2d677"), 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, 30000000, "1984" }
                });
        }
    }
}
