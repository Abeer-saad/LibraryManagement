using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryManagement.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUuidAndCleanArchitecture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "Customers",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "Categories",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "Borrowings",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uuid",
                table: "Books",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.Sql("UPDATE Customers SET Uuid = CONVERT(nvarchar(36), NEWID()) WHERE Uuid = ''");
            migrationBuilder.Sql("UPDATE Categories SET Uuid = CONVERT(nvarchar(36), NEWID()) WHERE Uuid = ''");
            migrationBuilder.Sql("UPDATE Borrowings SET Uuid = CONVERT(nvarchar(36), NEWID()) WHERE Uuid = ''");
            migrationBuilder.Sql("UPDATE Books SET Uuid = CONVERT(nvarchar(36), NEWID()) WHERE Uuid = ''");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Uuid",
                table: "Customers",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Uuid",
                table: "Categories",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Borrowings_Uuid",
                table: "Borrowings",
                column: "Uuid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Books_Uuid",
                table: "Books",
                column: "Uuid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Uuid",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Uuid",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Borrowings_Uuid",
                table: "Borrowings");

            migrationBuilder.DropIndex(
                name: "IX_Books_Uuid",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Borrowings");

            migrationBuilder.DropColumn(
                name: "Uuid",
                table: "Books");
        }
    }
}
