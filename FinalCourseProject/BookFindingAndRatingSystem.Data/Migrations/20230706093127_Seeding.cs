using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookFindingAndRatingSystem.Data.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Horror" },
                    { 2, "Romance" },
                    { 3, "Science Fiction" },
                    { 4, "Mystery" },
                    { 5, "Fantasy" },
                    { 6, "Thriller" },
                    { 7, "Comedy" },
                    { 8, "Fiction" }
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Penguin Random House" },
                    { 2, "HarperCollins" },
                    { 3, "Simon & Schuster" },
                    { 4, "Hachette Livre" },
                    { 5, "Macmillan Publishers" },
                    { 6, "Scholastic Corporation" },
                    { 7, "Pearson Education" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Publishers",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
