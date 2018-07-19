using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioterio.Migrations
{
    public partial class FixDoubleColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_PerfilId",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "IdPerfil",
                table: "AspNetUsers",
                type: "int(11)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdPerfil",
                table: "AspNetUsers",
                column: "IdPerfil");

            migrationBuilder.AddForeignKey(
                name: "fk_PerfilId",
                table: "AspNetUsers",
                column: "IdPerfil",
                principalTable: "perfil",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_PerfilId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_IdPerfil",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "IdPerfil",
                table: "AspNetUsers");

            migrationBuilder.AddForeignKey(
                name: "fk_PerfilId",
                table: "AspNetUsers",
                column: "IdFuncionario",
                principalTable: "perfil",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
