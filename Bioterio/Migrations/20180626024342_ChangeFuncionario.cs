using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioterio.Migrations
{
    public partial class ChangeFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "funcionario");

            migrationBuilder.DropColumn(
                name: "telefone",
                table: "funcionario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "funcionario",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "telefone",
                table: "funcionario",
                maxLength: 45,
                nullable: true);
        }
    }
}
