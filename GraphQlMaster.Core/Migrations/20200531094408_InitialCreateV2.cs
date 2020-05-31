using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQlMaster.Core.Migrations
{
    public partial class InitialCreateV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FoundedDate",
                table: "Brands",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FoundedDate",
                table: "Brands");
        }
    }
}
