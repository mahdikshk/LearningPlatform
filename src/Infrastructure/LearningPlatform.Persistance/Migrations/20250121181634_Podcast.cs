using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningPlatform.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Podcast : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Author_Id",
                table: "Podcasts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Podcasts_Author_Id",
                table: "Podcasts",
                column: "Author_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Podcasts_AspNetUsers_Author_Id",
                table: "Podcasts",
                column: "Author_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Podcasts_AspNetUsers_Author_Id",
                table: "Podcasts");

            migrationBuilder.DropIndex(
                name: "IX_Podcasts_Author_Id",
                table: "Podcasts");

            migrationBuilder.AlterColumn<string>(
                name: "Author_Id",
                table: "Podcasts",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
