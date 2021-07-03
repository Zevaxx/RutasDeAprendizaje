using Microsoft.EntityFrameworkCore.Migrations;

namespace RutasDeAprendizaje.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "USERLOGINSTATUS",
                table: "tusers",
                newName: "USERDESCRIPTION");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "USERDESCRIPTION",
                table: "tusers",
                newName: "USERLOGINSTATUS");
        }
    }
}
