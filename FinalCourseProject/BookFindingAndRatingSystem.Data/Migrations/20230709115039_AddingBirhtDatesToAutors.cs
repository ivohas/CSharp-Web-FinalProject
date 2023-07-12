using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookFindingAndRatingSystem.Data.Migrations
{
    public partial class AddingBirhtDatesToAutors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("06c113c6-0857-4063-bfa6-4542a011c417"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("31a1975d-a518-4512-9037-9280f3c3bb26"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5ccafe24-66a0-468d-8c59-0f6c0962d770"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6e4d741f-b78e-4a6b-b9a3-9372261412b5"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c068f961-c879-4fce-b280-2df1a1b6f3a4"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("f9503fa2-6cba-4234-81dd-e5ed6ca7a8f6"));

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Autors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 1,
                column: "BirthDate",
                value: new DateTime(1903, 6, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 2,
                column: "BirthDate",
                value: new DateTime(1919, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 3,
                column: "BirthDate",
                value: new DateTime(1896, 9, 24, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 4,
                column: "BirthDate",
                value: new DateTime(1892, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 5,
                column: "BirthDate",
                value: new DateTime(1965, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 6,
                column: "BirthDate",
                value: new DateTime(1926, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Autors",
                keyColumn: "Id",
                keyValue: 7,
                column: "BirthDate",
                value: new DateTime(1947, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AplicationUserId", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "Title" },
                values: new object[,]
                {
                    { new Guid("365606b6-91cc-462f-b38d-e384d7bdd8ce"), null, 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, "To Kill a Mockingbird" },
                    { new Guid("ac5e9819-9906-4edc-830d-483e9b00d91d"), null, 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("bb3bab06-8989-4f32-8307-f8a55a371d43"), null, 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, "The Great Gatsby" },
                    { new Guid("dde66f05-9f52-46e1-a13d-f4891aaf8da0"), null, 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, "1984" },
                    { new Guid("e1a9a6a8-3e75-4825-97cc-8bd2af168738"), null, 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, "The Hobbit" },
                    { new Guid("ef0b5a0b-8467-4085-89fa-a68f3496f4ce"), null, 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, "The Catcher in the Rye" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("365606b6-91cc-462f-b38d-e384d7bdd8ce"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ac5e9819-9906-4edc-830d-483e9b00d91d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("bb3bab06-8989-4f32-8307-f8a55a371d43"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("dde66f05-9f52-46e1-a13d-f4891aaf8da0"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e1a9a6a8-3e75-4825-97cc-8bd2af168738"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ef0b5a0b-8467-4085-89fa-a68f3496f4ce"));

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Autors");

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AplicationUserId", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "Title" },
                values: new object[,]
                {
                    { new Guid("06c113c6-0857-4063-bfa6-4542a011c417"), null, 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, "1984" },
                    { new Guid("31a1975d-a518-4512-9037-9280f3c3bb26"), null, 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, "The Hobbit" },
                    { new Guid("5ccafe24-66a0-468d-8c59-0f6c0962d770"), null, 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, "The Catcher in the Rye" },
                    { new Guid("6e4d741f-b78e-4a6b-b9a3-9372261412b5"), null, 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, "The Great Gatsby" },
                    { new Guid("c068f961-c879-4fce-b280-2df1a1b6f3a4"), null, 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, "To Kill a Mockingbird" },
                    { new Guid("f9503fa2-6cba-4234-81dd-e5ed6ca7a8f6"), null, 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, "Harry Potter and the Philosopher's Stone" }
                });
        }
    }
}
