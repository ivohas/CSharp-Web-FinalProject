using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookFindingAndRatingSystem.Data.Migrations
{
    public partial class AddingImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("1b9fad62-76c7-41ef-9a1d-8d9ffcbce038"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("26365da9-03e3-4c58-8d1d-e0cfccc6ebfc"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("56a83b63-21fe-4ad4-8488-81760e614ee1"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("95ee1592-ca97-4207-a0f8-ce827d6ee607"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("9aafce10-8b53-4f30-97a4-97a2372f81c8"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ea428fb5-240f-4593-b262-a2e9484393d2"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Books",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AplicationUserId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "Title" },
                values: new object[,]
                {
                    { new Guid("379cf5c3-7abb-4e41-b593-67bd19a81d4b"), null, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, "The Catcher in the Rye" },
                    { new Guid("4115cbb2-1002-43b6-860f-004bb406665d"), null, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("43804254-192b-43d7-864a-781dfcab3872"), null, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, "To Kill a Mockingbird" },
                    { new Guid("5413e233-96ac-40aa-97d9-d650c6f4f52a"), null, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, "1984" },
                    { new Guid("68533efd-2a4f-4f5f-9a73-bad5742988d8"), null, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, "The Great Gatsby" },
                    { new Guid("e99e0959-8c27-4591-9b3e-8143055729bd"), null, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, "The Hobbit" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("379cf5c3-7abb-4e41-b593-67bd19a81d4b"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4115cbb2-1002-43b6-860f-004bb406665d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("43804254-192b-43d7-864a-781dfcab3872"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5413e233-96ac-40aa-97d9-d650c6f4f52a"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("68533efd-2a4f-4f5f-9a73-bad5742988d8"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e99e0959-8c27-4591-9b3e-8143055729bd"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Books");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AplicationUserId", "CategoryId", "Description", "Pages", "Price", "PublishersId", "Title" },
                values: new object[,]
                {
                    { new Guid("1b9fad62-76c7-41ef-9a1d-8d9ffcbce038"), null, 5, "A fantasy novel by J.R.R. Tolkien", (short)304, 11.99f, 5, "The Hobbit" },
                    { new Guid("26365da9-03e3-4c58-8d1d-e0cfccc6ebfc"), null, 8, "A dystopian novel by George Orwell", (short)328, 9.99f, 2, "1984" },
                    { new Guid("56a83b63-21fe-4ad4-8488-81760e614ee1"), null, 8, "A novel by F. Scott Fitzgerald", (short)180, 7.99f, 4, "The Great Gatsby" },
                    { new Guid("95ee1592-ca97-4207-a0f8-ce827d6ee607"), null, 8, "A classic novel by Harper Lee", (short)336, 12.99f, 1, "To Kill a Mockingbird" },
                    { new Guid("9aafce10-8b53-4f30-97a4-97a2372f81c8"), null, 8, "A coming-of-age novel by J.D. Salinger", (short)224, 8.99f, 3, "The Catcher in the Rye" },
                    { new Guid("ea428fb5-240f-4593-b262-a2e9484393d2"), null, 5, "The first book in the Harry Potter series by J.K. Rowling", (short)332, 10.99f, 6, "Harry Potter and the Philosopher's Stone" }
                });
        }
    }
}
