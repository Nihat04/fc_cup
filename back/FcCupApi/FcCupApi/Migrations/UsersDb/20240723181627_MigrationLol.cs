using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FcCupApi.Migrations.UsersDb
{
    /// <inheritdoc />
    public partial class MigrationLol : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SubComment_AspNetUsers_AuthorId",
                table: "SubComment");

            migrationBuilder.DropForeignKey(
                name: "FK_SubComment_Forums_ForumId",
                table: "SubComment");

            migrationBuilder.DropForeignKey(
                name: "FK_SubComment_SubComment_CommentId",
                table: "SubComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubComment",
                table: "SubComment");

            migrationBuilder.DropIndex(
                name: "IX_SubComment_AuthorId",
                table: "SubComment");

            migrationBuilder.DropIndex(
                name: "IX_SubComment_CommentId",
                table: "SubComment");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "SubComment");

            migrationBuilder.RenameTable(
                name: "SubComment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_SubComment_ForumId",
                table: "Comments",
                newName: "IX_Comments_ForumId");

            migrationBuilder.AlterColumn<int>(
                name: "ForumId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "Comments",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "UserId",
                table: "Comments",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CommentRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CommentId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Rate = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentRatings", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Forums_ForumId",
                table: "Comments",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Forums_ForumId",
                table: "Comments");

            migrationBuilder.DropTable(
                name: "CommentRatings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "SubComment");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_ForumId",
                table: "SubComment",
                newName: "IX_SubComment_ForumId");

            migrationBuilder.AlterColumn<int>(
                name: "ForumId",
                table: "SubComment",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<long>(
                name: "AuthorId",
                table: "SubComment",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "SubComment",
                type: "varchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubComment",
                table: "SubComment",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubComment_AuthorId",
                table: "SubComment",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_SubComment_CommentId",
                table: "SubComment",
                column: "CommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_SubComment_AspNetUsers_AuthorId",
                table: "SubComment",
                column: "AuthorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubComment_Forums_ForumId",
                table: "SubComment",
                column: "ForumId",
                principalTable: "Forums",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SubComment_SubComment_CommentId",
                table: "SubComment",
                column: "CommentId",
                principalTable: "SubComment",
                principalColumn: "Id");
        }
    }
}
