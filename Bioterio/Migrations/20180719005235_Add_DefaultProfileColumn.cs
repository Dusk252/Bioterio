using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioterio.Migrations
{
    public partial class Add_DefaultProfileColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IsDefault",
                table: "perfil",
                type: "int(1)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDefault",
                table: "perfil");
        }
    }
}
