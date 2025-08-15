using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsPortal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_NewsArticles_Slug",
                table: "NewsArticles");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Slug",
                table: "Categories");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "NewsArticles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(180)",
                oldMaxLength: 180);

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "NewsArticles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "NewsArticles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(120)",
                oldMaxLength: 120);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { 1, "سیاست", "politics" },
                    { 2, "ورزش", "sports" },
                    { 3, "علم و فناوری", "technology" },
                    { 4, "فرهنگ و هنر", "culture" }
                });

            migrationBuilder.InsertData(
                table: "NewsArticles",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Content", "CreatedAt", "IsPublished", "PublishedAt", "Slug", "Summary", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, "SYSTEM", 1, "متن کامل خبر اول", new DateTimeOffset(new DateTime(2025, 8, 13, 16, 58, 49, 534, DateTimeKind.Unspecified).AddTicks(5128), new TimeSpan(0, 3, 30, 0, 0)), true, new DateTimeOffset(new DateTime(2025, 8, 13, 16, 58, 49, 534, DateTimeKind.Unspecified).AddTicks(5083), new TimeSpan(0, 3, 30, 0, 0)), "news-1", "خلاصه خبر اول", "خبر اول سایت خبری", null },
                    { 2, "SYSTEM", 2, "متن کامل خبر دوم", new DateTimeOffset(new DateTime(2025, 8, 13, 16, 58, 49, 534, DateTimeKind.Unspecified).AddTicks(5136), new TimeSpan(0, 3, 30, 0, 0)), true, new DateTimeOffset(new DateTime(2025, 8, 13, 16, 58, 49, 534, DateTimeKind.Unspecified).AddTicks(5134), new TimeSpan(0, 3, 30, 0, 0)), "news-2", "خلاصه خبر دوم", "خبر دوم سایت خبری", null },
                    { 3, "SYSTEM", 3, "متن کامل خبر سوم", new DateTimeOffset(new DateTime(2025, 8, 13, 16, 58, 49, 534, DateTimeKind.Unspecified).AddTicks(5142), new TimeSpan(0, 3, 30, 0, 0)), true, new DateTimeOffset(new DateTime(2025, 8, 13, 16, 58, 49, 534, DateTimeKind.Unspecified).AddTicks(5140), new TimeSpan(0, 3, 30, 0, 0)), "news-3", "خلاصه خبر سوم", "خبر سوم سایت خبری", null },
                    { 4, "SYSTEM", 4, "متن کامل خبر چهارم", new DateTimeOffset(new DateTime(2025, 8, 13, 16, 58, 49, 534, DateTimeKind.Unspecified).AddTicks(5148), new TimeSpan(0, 3, 30, 0, 0)), true, new DateTimeOffset(new DateTime(2025, 8, 13, 16, 58, 49, 534, DateTimeKind.Unspecified).AddTicks(5146), new TimeSpan(0, 3, 30, 0, 0)), "news-4", "خلاصه خبر چهارم", "خبر چهارم سایت خبری", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "NewsArticles",
                keyColumn: "Id",
                keyValue: 4);

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

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "NewsArticles",
                type: "nvarchar(180)",
                maxLength: 180,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Summary",
                table: "NewsArticles",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "NewsArticles",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Slug",
                table: "Categories",
                type: "nvarchar(120)",
                maxLength: 120,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_NewsArticles_Slug",
                table: "NewsArticles",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Slug",
                table: "Categories",
                column: "Slug",
                unique: true);
        }
    }
}
