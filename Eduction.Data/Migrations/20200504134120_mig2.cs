using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Eduction.Data.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Category_CategoryID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teacher_TeacherID",
                table: "Course");

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                table: "Teacher",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teacher",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherID",
                table: "Course",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Course",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnglishName",
                table: "Course",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateOn",
                table: "Category",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GetDate()");

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Category_CategoryID",
                table: "Course",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teacher_TeacherID",
                table: "Course",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Course_Category_CategoryID",
                table: "Course");

            migrationBuilder.DropForeignKey(
                name: "FK_Course_Teacher_TeacherID",
                table: "Course");

            migrationBuilder.DropColumn(
                name: "EnglishName",
                table: "Course");

            migrationBuilder.AlterColumn<int>(
                name: "NationalCode",
                table: "Teacher",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Teacher",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "TeacherID",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CategoryID",
                table: "Course",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateOn",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GetDate()",
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Category_CategoryID",
                table: "Course",
                column: "CategoryID",
                principalTable: "Category",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Course_Teacher_TeacherID",
                table: "Course",
                column: "TeacherID",
                principalTable: "Teacher",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
