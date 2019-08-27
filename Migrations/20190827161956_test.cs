using Microsoft.EntityFrameworkCore.Migrations;

namespace Circles_API.Migrations
{
    public partial class test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "userprofiles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_userprofiles_ApplicationUserId",
                table: "userprofiles",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_userprofiles_AspNetUsers_ApplicationUserId",
                table: "userprofiles",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userprofiles_AspNetUsers_ApplicationUserId",
                table: "userprofiles");

            migrationBuilder.DropIndex(
                name: "IX_userprofiles_ApplicationUserId",
                table: "userprofiles");

            migrationBuilder.AlterColumn<int>(
                name: "ApplicationUserId",
                table: "userprofiles",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
