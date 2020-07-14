using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eduction.Data.Migrations
{
    public partial class migtopic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateOn = table.Column<DateTime>(nullable: false),
                    UpdateOn = table.Column<DateTime>(nullable: false),
                    Title = table.Column<string>(maxLength: 150, nullable: false),
                    CourseID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Topic_Course_CourseID",
                        column: x => x.CourseID,
                        principalTable: "Course",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topic_CourseID",
                table: "Topic",
                column: "CourseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topic");
        }
    }
}
