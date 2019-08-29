using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Circles_API.Migrations
{
    public partial class SEJfhnSKHRgzkldjfg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "circles",
                columns: table => new
                {
                    CircleId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_circles", x => x.CircleId);
                });

            migrationBuilder.CreateTable(
                name: "tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "userprofiles",
                columns: table => new
                {
                    UserprofileId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    ApplicationUserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userprofiles", x => x.UserprofileId);
                });

            migrationBuilder.CreateTable(
                name: "CircleUserprofiles",
                columns: table => new
                {
                    CircleUserprofileId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CircleId = table.Column<int>(nullable: false),
                    UserprofileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CircleUserprofiles", x => x.CircleUserprofileId);
                    table.ForeignKey(
                        name: "FK_CircleUserprofiles_circles_CircleId",
                        column: x => x.CircleId,
                        principalTable: "circles",
                        principalColumn: "CircleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CircleUserprofiles_userprofiles_UserprofileId",
                        column: x => x.UserprofileId,
                        principalTable: "userprofiles",
                        principalColumn: "UserprofileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagUserprofiles",
                columns: table => new
                {
                    TagUserprofileId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TagId = table.Column<int>(nullable: false),
                    UserprofileId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagUserprofiles", x => x.TagUserprofileId);
                    table.ForeignKey(
                        name: "FK_TagUserprofiles_tags_TagId",
                        column: x => x.TagId,
                        principalTable: "tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagUserprofiles_userprofiles_UserprofileId",
                        column: x => x.UserprofileId,
                        principalTable: "userprofiles",
                        principalColumn: "UserprofileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CircleUserprofiles_CircleId",
                table: "CircleUserprofiles",
                column: "CircleId");

            migrationBuilder.CreateIndex(
                name: "IX_CircleUserprofiles_UserprofileId",
                table: "CircleUserprofiles",
                column: "UserprofileId");

            migrationBuilder.CreateIndex(
                name: "IX_TagUserprofiles_TagId",
                table: "TagUserprofiles",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_TagUserprofiles_UserprofileId",
                table: "TagUserprofiles",
                column: "UserprofileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CircleUserprofiles");

            migrationBuilder.DropTable(
                name: "TagUserprofiles");

            migrationBuilder.DropTable(
                name: "circles");

            migrationBuilder.DropTable(
                name: "tags");

            migrationBuilder.DropTable(
                name: "userprofiles");
        }
    }
}
