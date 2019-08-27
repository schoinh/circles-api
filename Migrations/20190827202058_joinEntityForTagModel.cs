using Microsoft.EntityFrameworkCore.Migrations;

namespace Circles_API.Migrations
{
    public partial class joinEntityForTagModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userprofiles_tags_TagId",
                table: "userprofiles");

            migrationBuilder.DropIndex(
                name: "IX_userprofiles_TagId",
                table: "userprofiles");

            migrationBuilder.DropColumn(
                name: "TagId",
                table: "userprofiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TagId",
                table: "userprofiles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userprofiles_TagId",
                table: "userprofiles",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_userprofiles_tags_TagId",
                table: "userprofiles",
                column: "TagId",
                principalTable: "tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
