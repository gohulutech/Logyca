using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Relations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Codes_Enterprises_OwnerId",
                table: "Codes");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Codes",
                newName: "ownerId");

            migrationBuilder.RenameIndex(
                name: "IX_Codes_OwnerId",
                table: "Codes",
                newName: "IX_Codes_ownerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Codes_Enterprises_ownerId",
                table: "Codes",
                column: "ownerId",
                principalTable: "Enterprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Codes_Enterprises_ownerId",
                table: "Codes");

            migrationBuilder.RenameColumn(
                name: "ownerId",
                table: "Codes",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Codes_ownerId",
                table: "Codes",
                newName: "IX_Codes_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Codes_Enterprises_OwnerId",
                table: "Codes",
                column: "OwnerId",
                principalTable: "Enterprises",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
