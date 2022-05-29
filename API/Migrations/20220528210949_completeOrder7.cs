using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class completeOrder7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "UseOfRefrigernats",
                newName: "NameUse");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameUse",
                table: "UseOfRefrigernats",
                newName: "Name");
        }
    }
}
