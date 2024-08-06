using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FcCupApi.Migrations.UsersDb
{
    /// <inheritdoc />
    public partial class MigrationSimple : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Forums",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "Forums");
        }
    }
}
