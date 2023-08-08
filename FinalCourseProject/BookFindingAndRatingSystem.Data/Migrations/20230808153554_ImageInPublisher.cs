using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookFindingAndRatingSystem.Data.Migrations
{
    public partial class ImageInPublisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("0b588825-9e99-466a-8bcd-610fd55b59eb"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4c0d9bab-e32e-42ca-826f-2635b1e672db"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("523625d5-7753-4402-a973-0ed9f03ec79c"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8c1d031a-1645-4b11-a719-86ff892bd631"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a2987c98-8cfc-4f43-adb6-2a36c8b1a93d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d0fd6a07-3c17-4414-a77a-68cd722a4873"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Publishers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "SelledCopies", "Title" },
                values: new object[,]
                {
                    { new Guid("764a0e2f-e27b-415a-a74f-16a03a37657b"), 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, 120000000, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("8d128d71-1068-44c3-b8b7-2ede4f71a5e7"), 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, 65000000, "The Catcher in the Rye" },
                    { new Guid("96863207-6e73-4b71-80c0-5ac1971111db"), 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, 100000000, "The Hobbit" },
                    { new Guid("d85c8881-4ae7-4831-abb7-ac6f9c542066"), 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, 25000000, "The Great Gatsby" },
                    { new Guid("dd71eaad-6cda-400d-85a6-cde4cdf558d8"), 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, 40000000, "To Kill a Mockingbird" },
                    { new Guid("f3b90025-fa21-4379-9fb8-41ebc731eaa7"), 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, 30000000, "1984" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("764a0e2f-e27b-415a-a74f-16a03a37657b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8d128d71-1068-44c3-b8b7-2ede4f71a5e7"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("96863207-6e73-4b71-80c0-5ac1971111db"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("d85c8881-4ae7-4831-abb7-ac6f9c542066"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("dd71eaad-6cda-400d-85a6-cde4cdf558d8"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f3b90025-fa21-4379-9fb8-41ebc731eaa7"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Publishers");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "SelledCopies", "Title" },
                values: new object[,]
                {
                    { new Guid("0b588825-9e99-466a-8bcd-610fd55b59eb"), 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, 120000000, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("4c0d9bab-e32e-42ca-826f-2635b1e672db"), 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, 40000000, "To Kill a Mockingbird" },
                    { new Guid("523625d5-7753-4402-a973-0ed9f03ec79c"), 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, 25000000, "The Great Gatsby" },
                    { new Guid("8c1d031a-1645-4b11-a719-86ff892bd631"), 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, 100000000, "The Hobbit" },
                    { new Guid("a2987c98-8cfc-4f43-adb6-2a36c8b1a93d"), 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, 65000000, "The Catcher in the Rye" },
                    { new Guid("d0fd6a07-3c17-4414-a77a-68cd722a4873"), 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, 30000000, "1984" }
                });
        }
    }
}
