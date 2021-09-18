using Microsoft.EntityFrameworkCore.Migrations;

namespace Manufacture_ASP.NET_MVC.Migrations
{
    public partial class complited_status_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Complited",
                table: "Export");

            migrationBuilder.AddColumn<string>(
                name: "ComplitedStatusId",
                table: "Export",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComplitedStatus",
                columns: table => new
                {
                    Status = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComplitedStatus", x => x.Status);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Export_ComplitedStatusId",
                table: "Export",
                column: "ComplitedStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Export_ComplitedStatus_ComplitedStatusId",
                table: "Export",
                column: "ComplitedStatusId",
                principalTable: "ComplitedStatus",
                principalColumn: "Status",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Export_ComplitedStatus_ComplitedStatusId",
                table: "Export");

            migrationBuilder.DropTable(
                name: "ComplitedStatus");

            migrationBuilder.DropIndex(
                name: "IX_Export_ComplitedStatusId",
                table: "Export");

            migrationBuilder.DropColumn(
                name: "ComplitedStatusId",
                table: "Export");

            migrationBuilder.AddColumn<string>(
                name: "Complited",
                table: "Export",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
