using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookFindingAndRatingSystem.Data.Migrations
{
    public partial class AddingAutor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "AutorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Autors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autors", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Autors",
                columns: new[] { "Id", "FirstName", "ImageUrl", "LastName" },
                values: new object[,]
                {
                    { 1, "George", "https://example.com/george-orwell.jpg", "Orwell" },
                    { 2, "J.D.", "https://example.com/jd-salinger.jpg", "Salinger" },
                    { 3, "F. Scott", "https://example.com/f-scott-fitzgerald.jpg", "Fitzgerald" },
                    { 4, "J.R.R.", "https://example.com/jrr-tolkien.jpg", "Tolkien" },
                    { 5, "J.K.", "https://example.com/jk-rowling.jpg", "Rowling" },
                    { 6, "Harper", "https://example.com/harper-lee.jpg", "Lee" },
                    { 7, "Stephen", "https://example.com/stephen-king.jpg", "King" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AplicationUserId", "AutorId", "CategoryId", "Description", "ImageUrl", "Pages", "Price", "PublishersId", "Title" },
                values: new object[,]
                {
                    { new Guid("013dcdef-f7db-47b2-8567-19071d240abb"), null, 2, 8, "A coming-of-age novel by J.D. Salinger", "https://m.media-amazon.com/images/I/61fgOuZfBGL._AC_UF1000,1000_QL80_.jpg", (short)224, 8.99f, 3, "The Catcher in the Rye" },
                    { new Guid("4a6f5f5f-ec2b-4854-a995-cba4a5d5d27d"), null, 6, 8, "A classic novel by Harper Lee", "https://upload.wikimedia.org/wikipedia/commons/4/4f/To_Kill_a_Mockingbird_%28first_edition_cover%29.jpg", (short)336, 12.99f, 1, "To Kill a Mockingbird" },
                    { new Guid("77ec2458-ee02-4bb6-97da-0ce7dd184147"), null, 3, 8, "A novel by F. Scott Fitzgerald", "https://www.hachettebookgroup.com/wp-content/uploads/2020/06/9780762498147-3.jpg?fit=572%2C750", (short)180, 7.99f, 4, "The Great Gatsby" },
                    { new Guid("95272621-ed1a-4988-a887-53aa90e5b39f"), null, 1, 8, "A dystopian novel by George Orwell", "https://knigomania.bg/media/catalog/product/cache/02f16ac392ba7c312a70e2f3c5d752a7/1/9/1984-9780451524935.jpg", (short)328, 9.99f, 2, "1984" },
                    { new Guid("a3b58236-340a-4a4c-87e1-dbfce3deeb86"), null, 5, 5, "The first book in the Harry Potter series by J.K. Rowling", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcS0Ro_Cc4bCs0AH3X_1UfgeuIB6PhU6j-sN6A&usqp=CAU", (short)332, 10.99f, 6, "Harry Potter and the Philosopher's Stone" },
                    { new Guid("feb1602c-9abe-4248-afb0-28e4c31e87cc"), null, 4, 5, "A fantasy novel by J.R.R. Tolkien", "https://i.gr-assets.com/images/S/compressed.photo.goodreads.com/books/1546071216l/5907.jpg", (short)304, 11.99f, 5, "The Hobbit" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AutorId",
                table: "Books",
                column: "AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_Autors_AutorId",
                table: "Books",
                column: "AutorId",
                principalTable: "Autors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_Autors_AutorId",
                table: "Books");

            migrationBuilder.DropTable(
                name: "Autors");

            migrationBuilder.DropIndex(
                name: "IX_Books_AutorId",
                table: "Books");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("013dcdef-f7db-47b2-8567-19071d240abb"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("4a6f5f5f-ec2b-4854-a995-cba4a5d5d27d"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("77ec2458-ee02-4bb6-97da-0ce7dd184147"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("95272621-ed1a-4988-a887-53aa90e5b39f"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("a3b58236-340a-4a4c-87e1-dbfce3deeb86"));

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("feb1602c-9abe-4248-afb0-28e4c31e87cc"));

            migrationBuilder.DropColumn(
                name: "AutorId",
                table: "Books");

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
    }
}
