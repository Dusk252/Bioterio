using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioterio.Migrations
{
    public partial class AddProfilesToDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "membroEquipa_idEquipa",
                table: "ensaio");

            migrationBuilder.AlterColumn<string>(
                name: "TipoEstatutoGeneticocol",
                table: "tipoestatutogenetico",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "T_Manutencao",
                table: "tipo_manuntecao",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "codidenttanque",
                table: "tanque",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "isarchived",
                table: "tanque",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "t_origem",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "isarchived",
                table: "reg_tratamento",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "nroremocoes",
                table: "reg_remocoes",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "causaMorte",
                table: "reg_remocoes",
                type: "char(1)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "isarchived",
                table: "reg_remocoes",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isarchived",
                table: "reg_manutencao",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "volAgua",
                table: "reg_cond_amb",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "temperatura",
                table: "reg_cond_amb",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "salinidadeAgua",
                table: "reg_cond_amb",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "nivelO2",
                table: "reg_cond_amb",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "isarchived",
                table: "reg_cond_amb",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isarchived",
                table: "reg_amostragens",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "Sobras",
                table: "reg_alimentar",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "isarchived",
                table: "reg_alimentar",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<sbyte>(
                name: "SubmisInsEurop",
                table: "projeto",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RefORBEA",
                table: "projeto",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "nroAnimaisAutoriz",
                table: "projeto",
                type: "int(11)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(11)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AutorizacaoDGVA",
                table: "projeto",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "isarchived",
                table: "projeto",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<float>(
                name: "Racao",
                table: "plano_alimentar",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MarcaAlim",
                table: "plano_alimentar",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                table: "lote",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Localidade",
                table: "localcaptura",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "T_Finalidade",
                table: "finalidade",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nroAnimaisAutoriz",
                table: "ensaio",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "isarchived",
                table: "ensaio",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "elementoequipa",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "isarchived",
                table: "elementoequipa",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "nomeDistrito",
                table: "distrito",
                maxLength: 45,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 45,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "codigoCircuito",
                table: "circuito_tanque",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 15,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "isarchived",
                table: "circuito_tanque",
                type: "int(1)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "perfil",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomePerfil = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil", x => x.IdPerfil);
                });

            migrationBuilder.CreateTable(
                name: "profilerole",
                columns: table => new
                {
                    IdPerfil = table.Column<int>(type: "int(11)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(256)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_profilerole", x => new { x.IdPerfil, x.RoleId });
                    table.ForeignKey(
                        name: "fk_IdPerfil",
                        column: x => x.IdPerfil,
                        principalTable: "perfil",
                        principalColumn: "IdPerfil",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "fk_ProfileRole_Profile_idx",
                table: "profilerole",
                column: "IdPerfil");

            migrationBuilder.CreateIndex(
                name: "fk_ProfileRole_Role_idx",
                table: "profilerole",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "fk_PerfilId",
                table: "AspNetUsers",
                column: "IdFuncionario",
                principalTable: "perfil",
                principalColumn: "IdPerfil",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_PerfilId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "profilerole");

            migrationBuilder.DropTable(
                name: "perfil");

            migrationBuilder.DropColumn(
                name: "codidenttanque",
                table: "tanque");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "tanque");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "reg_tratamento");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "reg_remocoes");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "reg_manutencao");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "reg_cond_amb");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "reg_amostragens");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "reg_alimentar");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "projeto");

            migrationBuilder.DropColumn(
                name: "nroAnimaisAutoriz",
                table: "ensaio");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "ensaio");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "elementoequipa");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "elementoequipa");

            migrationBuilder.DropColumn(
                name: "isarchived",
                table: "circuito_tanque");

            migrationBuilder.AlterColumn<string>(
                name: "TipoEstatutoGeneticocol",
                table: "tipoestatutogenetico",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "T_Manutencao",
                table: "tipo_manuntecao",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "descricao",
                table: "t_origem",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<int>(
                name: "nroremocoes",
                table: "reg_remocoes",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<string>(
                name: "causaMorte",
                table: "reg_remocoes",
                type: "char(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)");

            migrationBuilder.AlterColumn<float>(
                name: "volAgua",
                table: "reg_cond_amb",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<float>(
                name: "temperatura",
                table: "reg_cond_amb",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<float>(
                name: "salinidadeAgua",
                table: "reg_cond_amb",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<float>(
                name: "nivelO2",
                table: "reg_cond_amb",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<float>(
                name: "Sobras",
                table: "reg_alimentar",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<sbyte>(
                name: "SubmisInsEurop",
                table: "projeto",
                type: "tinyint(1)",
                nullable: true,
                oldClrType: typeof(sbyte),
                oldType: "tinyint(1)");

            migrationBuilder.AlterColumn<int>(
                name: "RefORBEA",
                table: "projeto",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<int>(
                name: "nroAnimaisAutoriz",
                table: "projeto",
                type: "int(11)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int(11)");

            migrationBuilder.AlterColumn<string>(
                name: "AutorizacaoDGVA",
                table: "projeto",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<float>(
                name: "Racao",
                table: "plano_alimentar",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<string>(
                name: "MarcaAlim",
                table: "plano_alimentar",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Observacoes",
                table: "lote",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "Localidade",
                table: "localcaptura",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "T_Finalidade",
                table: "finalidade",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AddColumn<int>(
                name: "membroEquipa_idEquipa",
                table: "ensaio",
                type: "int(11)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "nomeDistrito",
                table: "distrito",
                maxLength: 45,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 45);

            migrationBuilder.AlterColumn<string>(
                name: "codigoCircuito",
                table: "circuito_tanque",
                maxLength: 15,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 15);
        }
    }
}
