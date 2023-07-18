using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookFindingAndRatingSystem.Data.Migrations
{
    public partial class NewPropertyInBookForLinkWithUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("02afd6bf-5e0b-46b0-b1e2-d1192a004f07"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("08dfabbe-274a-4f9d-93d2-45594b7e8eda"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("37dfbe45-eddf-4fd5-957d-cca1aeac7f60"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("573453dd-55e9-46f1-a5cc-41136fdea435"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("58b4ae91-2cdc-4e2d-a896-f8f257254fa6"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9b58bf0c-8838-4f78-a88b-a6ba975d083f"));

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "SelledCopies", "Title" },
                values: new object[,]
                {
                    { new Guid("02afd6bf-5e0b-46b0-b1e2-d1192a004f07"), 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, 65000000, "The Catcher in the Rye" },
                    { new Guid("08dfabbe-274a-4f9d-93d2-45594b7e8eda"), 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, 40000000, "To Kill a Mockingbird" },
                    { new Guid("37dfbe45-eddf-4fd5-957d-cca1aeac7f60"), 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, 100000000, "The Hobbit" },
                    { new Guid("573453dd-55e9-46f1-a5cc-41136fdea435"), 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, 120000000, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("58b4ae91-2cdc-4e2d-a896-f8f257254fa6"), 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, 25000000, "The Great Gatsby" },
                    { new Guid("9b58bf0c-8838-4f78-a88b-a6ba975d083f"), 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, 30000000, "1984" }
                });
        }
    }
}
