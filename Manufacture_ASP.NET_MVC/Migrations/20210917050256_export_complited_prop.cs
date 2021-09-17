using Microsoft.EntityFrameworkCore.Migrations;

namespace Manufacture_ASP.NET_MVC.Migrations
{
    public partial class export_complited_prop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Export");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Export",
                newName: "Complited");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Complited",
                table: "Export",
                newName: "FullName");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Export",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
