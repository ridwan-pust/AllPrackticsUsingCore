using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AllPrackticsUsingCore.Migrations
{
    public partial class FinialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "Student");

            migrationBuilder.AddColumn<byte[]>(
                name: "Picture",
                table: "Student",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "image",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "image",
                table: "Student");

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "Student",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
