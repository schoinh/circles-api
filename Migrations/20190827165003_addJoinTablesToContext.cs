using Microsoft.EntityFrameworkCore.Migrations;

namespace Circles_API.Migrations
{
    public partial class addJoinTablesToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CircleUserprofile_circles_CircleId",
                table: "CircleUserprofile");

            migrationBuilder.DropForeignKey(
                name: "FK_CircleUserprofile_userprofiles_UserprofileId",
                table: "CircleUserprofile");

            migrationBuilder.DropForeignKey(
                name: "FK_TagUserprofile_tags_TagId",
                table: "TagUserprofile");

            migrationBuilder.DropForeignKey(
                name: "FK_TagUserprofile_userprofiles_UserprofileId",
                table: "TagUserprofile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagUserprofile",
                table: "TagUserprofile");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CircleUserprofile",
                table: "CircleUserprofile");

            migrationBuilder.RenameTable(
                name: "TagUserprofile",
                newName: "TagUserprofiles");

            migrationBuilder.RenameTable(
                name: "CircleUserprofile",
                newName: "CircleUserprofiles");

            migrationBuilder.RenameIndex(
                name: "IX_TagUserprofile_UserprofileId",
                table: "TagUserprofiles",
                newName: "IX_TagUserprofiles_UserprofileId");

            migrationBuilder.RenameIndex(
                name: "IX_TagUserprofile_TagId",
                table: "TagUserprofiles",
                newName: "IX_TagUserprofiles_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_CircleUserprofile_UserprofileId",
                table: "CircleUserprofiles",
                newName: "IX_CircleUserprofiles_UserprofileId");

            migrationBuilder.RenameIndex(
                name: "IX_CircleUserprofile_CircleId",
                table: "CircleUserprofiles",
                newName: "IX_CircleUserprofiles_CircleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagUserprofiles",
                table: "TagUserprofiles",
                column: "TagUserprofileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CircleUserprofiles",
                table: "CircleUserprofiles",
                column: "CircleUserprofileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CircleUserprofiles_circles_CircleId",
                table: "CircleUserprofiles",
                column: "CircleId",
                principalTable: "circles",
                principalColumn: "CircleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CircleUserprofiles_userprofiles_UserprofileId",
                table: "CircleUserprofiles",
                column: "UserprofileId",
                principalTable: "userprofiles",
                principalColumn: "UserprofileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagUserprofiles_tags_TagId",
                table: "TagUserprofiles",
                column: "TagId",
                principalTable: "tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagUserprofiles_userprofiles_UserprofileId",
                table: "TagUserprofiles",
                column: "UserprofileId",
                principalTable: "userprofiles",
                principalColumn: "UserprofileId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CircleUserprofiles_circles_CircleId",
                table: "CircleUserprofiles");

            migrationBuilder.DropForeignKey(
                name: "FK_CircleUserprofiles_userprofiles_UserprofileId",
                table: "CircleUserprofiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TagUserprofiles_tags_TagId",
                table: "TagUserprofiles");

            migrationBuilder.DropForeignKey(
                name: "FK_TagUserprofiles_userprofiles_UserprofileId",
                table: "TagUserprofiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TagUserprofiles",
                table: "TagUserprofiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CircleUserprofiles",
                table: "CircleUserprofiles");

            migrationBuilder.RenameTable(
                name: "TagUserprofiles",
                newName: "TagUserprofile");

            migrationBuilder.RenameTable(
                name: "CircleUserprofiles",
                newName: "CircleUserprofile");

            migrationBuilder.RenameIndex(
                name: "IX_TagUserprofiles_UserprofileId",
                table: "TagUserprofile",
                newName: "IX_TagUserprofile_UserprofileId");

            migrationBuilder.RenameIndex(
                name: "IX_TagUserprofiles_TagId",
                table: "TagUserprofile",
                newName: "IX_TagUserprofile_TagId");

            migrationBuilder.RenameIndex(
                name: "IX_CircleUserprofiles_UserprofileId",
                table: "CircleUserprofile",
                newName: "IX_CircleUserprofile_UserprofileId");

            migrationBuilder.RenameIndex(
                name: "IX_CircleUserprofiles_CircleId",
                table: "CircleUserprofile",
                newName: "IX_CircleUserprofile_CircleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TagUserprofile",
                table: "TagUserprofile",
                column: "TagUserprofileId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CircleUserprofile",
                table: "CircleUserprofile",
                column: "CircleUserprofileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CircleUserprofile_circles_CircleId",
                table: "CircleUserprofile",
                column: "CircleId",
                principalTable: "circles",
                principalColumn: "CircleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CircleUserprofile_userprofiles_UserprofileId",
                table: "CircleUserprofile",
                column: "UserprofileId",
                principalTable: "userprofiles",
                principalColumn: "UserprofileId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagUserprofile_tags_TagId",
                table: "TagUserprofile",
                column: "TagId",
                principalTable: "tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TagUserprofile_userprofiles_UserprofileId",
                table: "TagUserprofile",
                column: "UserprofileId",
                principalTable: "userprofiles",
                principalColumn: "UserprofileId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
