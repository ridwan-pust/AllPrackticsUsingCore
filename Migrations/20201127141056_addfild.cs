using Microsoft.EntityFrameworkCore.Migrations;

namespace AllPrackticsUsingCore.Migrations
{
    public partial class addfild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nationality",
                table: "Student",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nationality",
                table: "Student");
        }
    }
}
