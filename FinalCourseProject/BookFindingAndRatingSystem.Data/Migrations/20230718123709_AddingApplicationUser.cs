using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookFindingAndRatingSystem.Data.Migrations
{
    public partial class AddingApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("08111c1a-12f4-4e5e-9831-879d3e9c2eb7"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("84250d36-853e-4b80-bdbf-88e9b36ab714"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a2cc9299-e2a8-488b-a394-fd4e7f7fe089"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a36ffb34-25a6-4ee7-bf79-a30c78e64dd7"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d53c80fa-a689-4ef6-80cc-0706780939eb"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e26ebc7f-ce76-4756-852b-ad2a1628ce11"));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AplicationUserId", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "SelledCopies", "Title" },
                values: new object[,]
                {
                    { new Guid("25c790cf-caad-4c56-967f-9fc14ffc06fc"), null, 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, 30000000, "1984" },
                    { new Guid("5bd12d19-60c8-4bc7-81c6-e0dd691a163b"), null, 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, 65000000, "The Catcher in the Rye" },
                    { new Guid("5c5ebc9c-bd68-4a9f-8280-34e60d2ef1c2"), null, 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, 25000000, "The Great Gatsby" },
                    { new Guid("78da0363-2a54-42bc-bbb1-d6eea9bbfbee"), null, 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, 40000000, "To Kill a Mockingbird" },
                    { new Guid("85ed0c95-695f-4ff2-8534-b3de655c6bed"), null, 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, 120000000, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("89a34884-e336-45b8-8ca5-a6c14b4b7370"), null, 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, 100000000, "The Hobbit" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("25c790cf-caad-4c56-967f-9fc14ffc06fc"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5bd12d19-60c8-4bc7-81c6-e0dd691a163b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5c5ebc9c-bd68-4a9f-8280-34e60d2ef1c2"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("78da0363-2a54-42bc-bbb1-d6eea9bbfbee"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("85ed0c95-695f-4ff2-8534-b3de655c6bed"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("89a34884-e336-45b8-8ca5-a6c14b4b7370"));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AplicationUserId", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "SelledCopies", "Title" },
                values: new object[,]
                {
                    { new Guid("08111c1a-12f4-4e5e-9831-879d3e9c2eb7"), null, 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, 120000000, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("84250d36-853e-4b80-bdbf-88e9b36ab714"), null, 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, 25000000, "The Great Gatsby" },
                    { new Guid("a2cc9299-e2a8-488b-a394-fd4e7f7fe089"), null, 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, 100000000, "The Hobbit" },
                    { new Guid("a36ffb34-25a6-4ee7-bf79-a30c78e64dd7"), null, 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, 40000000, "To Kill a Mockingbird" },
                    { new Guid("d53c80fa-a689-4ef6-80cc-0706780939eb"), null, 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, 30000000, "1984" },
                    { new Guid("e26ebc7f-ce76-4756-852b-ad2a1628ce11"), null, 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, 65000000, "The Catcher in the Rye" }
                });
        }
    }
}
