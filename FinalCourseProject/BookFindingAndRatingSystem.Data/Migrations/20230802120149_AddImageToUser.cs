using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookFindingAndRatingSystem.Data.Migrations
{
    public partial class AddImageToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("177d4913-9545-4bb2-a040-62289e660cde"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1ca261b6-59e0-47b0-8f42-d2113ab05ec1"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("49a0932c-fe9a-4228-af9c-62a7b3c75a20"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8bfe61ca-e9b3-4590-b2b9-530fdc434e2d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("8dc14624-d7e2-4028-8fb6-3266103107a3"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("98379836-c67a-452f-be8d-a3eb32535eca"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "SelledCopies", "Title" },
                values: new object[,]
                {
                    { new Guid("189b8299-f6ca-4bc9-830d-eb5d79c14fc4"), 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, 25000000, "The Great Gatsby" },
                    { new Guid("2402882f-a5bd-43a8-b679-a3cb241511ae"), 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, 40000000, "To Kill a Mockingbird" },
                    { new Guid("534c586d-febf-4eeb-ad14-d9364679e709"), 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, 120000000, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("7f92dec3-2687-40ea-aa1a-76888cfeba76"), 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, 100000000, "The Hobbit" },
                    { new Guid("94106601-a1c3-4360-88b5-30a6b6dc2f81"), 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, 65000000, "The Catcher in the Rye" },
                    { new Guid("c819c66c-8db5-4b3f-96bb-797e8480336f"), 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, 30000000, "1984" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("189b8299-f6ca-4bc9-830d-eb5d79c14fc4"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("2402882f-a5bd-43a8-b679-a3cb241511ae"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("534c586d-febf-4eeb-ad14-d9364679e709"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("7f92dec3-2687-40ea-aa1a-76888cfeba76"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("94106601-a1c3-4360-88b5-30a6b6dc2f81"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c819c66c-8db5-4b3f-96bb-797e8480336f"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "SelledCopies", "Title" },
                values: new object[,]
                {
                    { new Guid("177d4913-9545-4bb2-a040-62289e660cde"), 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, 25000000, "The Great Gatsby" },
                    { new Guid("1ca261b6-59e0-47b0-8f42-d2113ab05ec1"), 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, 40000000, "To Kill a Mockingbird" },
                    { new Guid("49a0932c-fe9a-4228-af9c-62a7b3c75a20"), 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, 120000000, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("8bfe61ca-e9b3-4590-b2b9-530fdc434e2d"), 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, 100000000, "The Hobbit" },
                    { new Guid("8dc14624-d7e2-4028-8fb6-3266103107a3"), 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, 65000000, "The Catcher in the Rye" },
                    { new Guid("98379836-c67a-452f-be8d-a3eb32535eca"), 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, 30000000, "1984" }
                });
        }
    }
}
