using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace chucknorris.API.Migrations
{
    /// <inheritdoc />
    public partial class removecolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "Jokes");

            migrationBuilder.DropColumn(
                name: "icon_url",
                table: "Jokes");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "Jokes");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "created_at",
                table: "Jokes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "icon_url",
                table: "Jokes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "updated_at",
                table: "Jokes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
