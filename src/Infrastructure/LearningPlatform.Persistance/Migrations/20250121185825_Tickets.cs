using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearningPlatform.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class Tickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author_Id",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Tickets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_Author_Id",
                table: "Tickets",
                column: "Author_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_AspNetUsers_Author_Id",
                table: "Tickets",
                column: "Author_Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_AspNetUsers_Author_Id",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_Author_Id",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Author_Id",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Text",
                table: "Tickets");
        }
    }
}
