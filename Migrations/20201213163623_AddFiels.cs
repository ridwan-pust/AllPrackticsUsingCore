using Microsoft.EntityFrameworkCore.Migrations;

namespace AllPrackticsUsingCore.Migrations
{
    public partial class AddFiels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "BedInformation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Shift",
                table: "BedInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "BedInformation");

            migrationBuilder.DropColumn(
                name: "Shift",
                table: "BedInformation");
        }
    }
}
