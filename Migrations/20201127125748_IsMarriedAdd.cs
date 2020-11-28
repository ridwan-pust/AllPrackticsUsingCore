using Microsoft.EntityFrameworkCore.Migrations;

namespace AllPrackticsUsingCore.Migrations
{
    public partial class IsMarriedAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsMarried",
                table: "Student",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMarried",
                table: "Student");
        }
    }
}
