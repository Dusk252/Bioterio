using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bioterio.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agente_trat",
                columns: table => new
                {
                    idAgenTra = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeAgenTra = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agente_trat", x => x.idAgenTra);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "distrito",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeDistrito = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_distrito", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "finalidade",
                columns: table => new
                {
                    idFinalidade = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    T_Finalidade = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_finalidade", x => x.idFinalidade);
                });

            migrationBuilder.CreateTable(
                name: "fornecedorcolector",
                columns: table => new
                {
                    idFornColect = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Tipo = table.Column<string>(type: "char(1)", nullable: false),
                    Nome = table.Column<string>(maxLength: 45, nullable: false),
                    NIF = table.Column<int>(type: "int(10)", nullable: false),
                    nroLicenca = table.Column<int>(type: "int(11)", nullable: false),
                    Morada = table.Column<string>(maxLength: 45, nullable: false),
                    telefone = table.Column<string>(maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedorcolector", x => x.idFornColect);
                });

            migrationBuilder.CreateTable(
                name: "funcionario",
                columns: table => new
                {
                    idFuncionario = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeCompleto = table.Column<string>(maxLength: 45, nullable: false),
                    PasswordHash = table.Column<string>(nullable: false),
                    telefone = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionario", x => x.idFuncionario);
                });

            migrationBuilder.CreateTable(
                name: "grupo",
                columns: table => new
                {
                    idGrupo = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeGrupo = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_grupo", x => x.idGrupo);
                });

            migrationBuilder.CreateTable(
                name: "motivo",
                columns: table => new
                {
                    idMotivo = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    tipoMotivo = table.Column<string>(maxLength: 45, nullable: false),
                    nomeMotivo = table.Column<string>(maxLength: 45, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_motivo", x => x.idMotivo);
                });

            migrationBuilder.CreateTable(
                name: "plano_alimentar",
                columns: table => new
                {
                    idPlanAlim = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false),
                    MarcaAlim = table.Column<string>(maxLength: 45, nullable: true),
                    Tipo = table.Column<int>(type: "int(11)", nullable: false),
                    Temperatura = table.Column<float>(nullable: false),
                    Racao = table.Column<float>(nullable: true),
                    RacaoDia = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_plano_alimentar", x => x.idPlanAlim);
                });

            migrationBuilder.CreateTable(
                name: "projeto",
                columns: table => new
                {
                    idProjeto = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 45, nullable: false),
                    dataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    dataFim = table.Column<DateTime>(type: "datetime", nullable: false),
                    AutorizacaoDGVA = table.Column<string>(maxLength: 45, nullable: true),
                    RefORBEA = table.Column<int>(type: "int(11)", nullable: true),
                    SubmisInsEurop = table.Column<sbyte>(type: "tinyint(1)", nullable: true),
                    nroAnimaisAutoriz = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_projeto", x => x.idProjeto);
                });

            migrationBuilder.CreateTable(
                name: "t_origem",
                columns: table => new
                {
                    idT_Origem = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Descrição = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_origem", x => x.idT_Origem);
                });

            migrationBuilder.CreateTable(
                name: "tipo_manuntecao",
                columns: table => new
                {
                    idT_Manutencao = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    T_Manutencao = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipo_manuntecao", x => x.idT_Manutencao);
                });

            migrationBuilder.CreateTable(
                name: "tipoestatutogenetico",
                columns: table => new
                {
                    idTipoEstatutoGenetico = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TipoEstatutoGeneticocol = table.Column<string>(maxLength: 45, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tipoestatutogenetico", x => x.idTipoEstatutoGenetico);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "concelho",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nomeConcelho = table.Column<string>(maxLength: 45, nullable: false),
                    Distrito_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_concelho", x => x.id);
                    table.ForeignKey(
                        name: "fk_Concelho_Distrito1",
                        column: x => x.Distrito_id,
                        principalTable: "distrito",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 45, nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    IdFuncionario = table.Column<int>(type: "int(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "fk_FuncionarioIdFuncionario",
                        column: x => x.IdFuncionario,
                        principalTable: "funcionario",
                        principalColumn: "idFuncionario",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "familia",
                columns: table => new
                {
                    idFamilia = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeFamilia = table.Column<string>(maxLength: 45, nullable: false),
                    Grupo_idGrupo = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_familia", x => x.idFamilia);
                    table.ForeignKey(
                        name: "fk_Familia_Grupo1",
                        column: x => x.Grupo_idGrupo,
                        principalTable: "grupo",
                        principalColumn: "idGrupo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "circuito_tanque",
                columns: table => new
                {
                    idCircuito = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Projeto_idProjeto = table.Column<int>(type: "int(11)", nullable: false),
                    codigoCircuito = table.Column<string>(maxLength: 15, nullable: true),
                    dataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    dataFinal = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_circuito_tanque", x => x.idCircuito);
                    table.ForeignKey(
                        name: "fk_Circuito_Tanque_Projeto1",
                        column: x => x.Projeto_idProjeto,
                        principalTable: "projeto",
                        principalColumn: "idProjeto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "elementoequipa",
                columns: table => new
                {
                    idElementoEquipa = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    função = table.Column<string>(maxLength: 40, nullable: false),
                    Projeto_idProjeto = table.Column<int>(type: "int(11)", nullable: false),
                    Funcionario_idFuncionario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_elementoequipa", x => x.idElementoEquipa);
                    table.ForeignKey(
                        name: "fk_equipaProjeto_Funcionario1",
                        column: x => x.Funcionario_idFuncionario,
                        principalTable: "funcionario",
                        principalColumn: "idFuncionario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_equipaProjeto_Projeto1",
                        column: x => x.Projeto_idProjeto,
                        principalTable: "projeto",
                        principalColumn: "idProjeto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "localcaptura",
                columns: table => new
                {
                    idLocalCaptura = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Localidade = table.Column<string>(maxLength: 45, nullable: true),
                    Latitude = table.Column<float>(type: "float(10,6)", nullable: true),
                    Longitude = table.Column<float>(type: "float(10,6)", nullable: true),
                    Concelho_id = table.Column<int>(type: "int(11)", nullable: false),
                    Distrito_id = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_localcaptura", x => x.idLocalCaptura);
                    table.ForeignKey(
                        name: "fk_LocalCaptura_Concelho1",
                        column: x => x.Concelho_id,
                        principalTable: "concelho",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_LocalCaptura_Distrito1",
                        column: x => x.Distrito_id,
                        principalTable: "distrito",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "especie",
                columns: table => new
                {
                    idEspecie = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    NomeCient = table.Column<string>(maxLength: 45, nullable: false),
                    NomeVulgar = table.Column<string>(maxLength: 45, nullable: false),
                    Familia_idFamilia = table.Column<int>(type: "int(11)", nullable: false),
                    Grupo_idGrupo = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_especie", x => x.idEspecie);
                    table.ForeignKey(
                        name: "fk_Especie_Familia1",
                        column: x => x.Familia_idFamilia,
                        principalTable: "familia",
                        principalColumn: "idFamilia",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Especie_Grupo1",
                        column: x => x.Grupo_idGrupo,
                        principalTable: "grupo",
                        principalColumn: "idGrupo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reg_cond_amb",
                columns: table => new
                {
                    idRegCondAmb = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(type: "datetime", nullable: false),
                    temperatura = table.Column<float>(nullable: true),
                    volAgua = table.Column<float>(nullable: true),
                    salinidadeAgua = table.Column<float>(nullable: true),
                    nivelO2 = table.Column<float>(nullable: true),
                    Circuito_Tanque_idCircuito = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reg_cond_amb", x => x.idRegCondAmb);
                    table.ForeignKey(
                        name: "fk_Reg_Cond_Amb_Circuito_Tanque1",
                        column: x => x.Circuito_Tanque_idCircuito,
                        principalTable: "circuito_tanque",
                        principalColumn: "idCircuito",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reg_novos_animais",
                columns: table => new
                {
                    idRegAnimal = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nroExemplares = table.Column<int>(type: "int(11)", nullable: false),
                    nroMachos = table.Column<int>(type: "int(11)", nullable: true),
                    nroFemeas = table.Column<int>(type: "int(11)", nullable: true),
                    Imaturos = table.Column<int>(type: "int(11)", nullable: true),
                    Juvenis = table.Column<int>(type: "int(11)", nullable: true),
                    Larvas = table.Column<int>(type: "int(11)", nullable: true),
                    Ovos = table.Column<int>(type: "int(11)", nullable: true),
                    dataNasc = table.Column<DateTime>(type: "datetime", nullable: true),
                    idade = table.Column<int>(type: "int(11)", nullable: true),
                    pesoMedio = table.Column<float>(nullable: true),
                    compMedio = table.Column<float>(nullable: true),
                    DuracaoViagem = table.Column<TimeSpan>(type: "time", nullable: true),
                    tempPartida = table.Column<int>(type: "int(11)", nullable: true),
                    tempChegada = table.Column<int>(type: "int(11)", nullable: true),
                    nroContentores = table.Column<int>(type: "int(11)", nullable: true),
                    tipoContentor = table.Column<string>(maxLength: 45, nullable: false),
                    volContentor = table.Column<float>(nullable: true),
                    volAgua = table.Column<float>(nullable: true),
                    nroCaixasIsoter = table.Column<int>(type: "int(11)", nullable: true),
                    nroMortosCheg = table.Column<int>(type: "int(11)", nullable: true),
                    satO2Transp = table.Column<float>(nullable: true),
                    anestesico = table.Column<float>(nullable: true),
                    Gelo = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    Adicao_O2 = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    Arejamento = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    refrigeracao = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    sedação = table.Column<sbyte>(type: "tinyint(1)", nullable: false),
                    respTransporte = table.Column<string>(maxLength: 45, nullable: false),
                    Especie_idEspecie = table.Column<int>(type: "int(11)", nullable: false),
                    Fornecedor_idFornColect = table.Column<int>(type: "int(11)", nullable: false),
                    T_Origem_idT_Origem = table.Column<int>(type: "int(11)", nullable: false),
                    LocalCaptura_idLocalCaptura = table.Column<int>(type: "int(11)", nullable: true),
                    TipoEstatutoGenetico_idTipoEstatutoGenetico = table.Column<int>(type: "int(11)", nullable: false),
                    Funcionario_idFuncionario = table.Column<int>(nullable: false),
                    Funcionario_idFuncionario1 = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reg_novos_animais", x => x.idRegAnimal);
                    table.ForeignKey(
                        name: "fk_Reg_Novos_Animais_Especie1",
                        column: x => x.Especie_idEspecie,
                        principalTable: "especie",
                        principalColumn: "idEspecie",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Reg_Novos_Animais_Fornecedor1",
                        column: x => x.Fornecedor_idFornColect,
                        principalTable: "fornecedorcolector",
                        principalColumn: "idFornColect",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Reg_Novos_Animais_Funcionario1",
                        column: x => x.Funcionario_idFuncionario,
                        principalTable: "funcionario",
                        principalColumn: "idFuncionario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Reg_Novos_Animais_Funcionario2",
                        column: x => x.Funcionario_idFuncionario1,
                        principalTable: "funcionario",
                        principalColumn: "idFuncionario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Reg_Novos_Animais_LocalCaptura1",
                        column: x => x.LocalCaptura_idLocalCaptura,
                        principalTable: "localcaptura",
                        principalColumn: "idLocalCaptura",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Reg_Novos_Animais_T_Origem1",
                        column: x => x.T_Origem_idT_Origem,
                        principalTable: "t_origem",
                        principalColumn: "idT_Origem",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Reg_Novos_Animais_TipoEstatutoGenetico1",
                        column: x => x.TipoEstatutoGenetico_idTipoEstatutoGenetico,
                        principalTable: "tipoestatutogenetico",
                        principalColumn: "idTipoEstatutoGenetico",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lote",
                columns: table => new
                {
                    idLote = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    codigoLote = table.Column<string>(maxLength: 10, nullable: false),
                    dataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    dataFim = table.Column<DateTime>(type: "datetime", nullable: true),
                    Observacoes = table.Column<string>(maxLength: 45, nullable: true),
                    Reg_Novos_Animais_idRegAnimal = table.Column<int>(type: "int(11)", nullable: false),
                    Funcionario_idFuncionario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lote", x => x.idLote);
                    table.ForeignKey(
                        name: "fk_Lote_Funcionario1",
                        column: x => x.Funcionario_idFuncionario,
                        principalTable: "funcionario",
                        principalColumn: "idFuncionario",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Lote_Reg_Novos_Animais1",
                        column: x => x.Reg_Novos_Animais_idRegAnimal,
                        principalTable: "reg_novos_animais",
                        principalColumn: "idRegAnimal",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ensaio",
                columns: table => new
                {
                    idEnsaio = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    dataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    dataFim = table.Column<DateTime>(type: "datetime", nullable: false),
                    descTratamento = table.Column<string>(maxLength: 45, nullable: false),
                    grauSeveridade = table.Column<int>(type: "int(11)", nullable: false),
                    Projeto_idProjeto = table.Column<int>(type: "int(11)", nullable: false),
                    Lote_idLote = table.Column<int>(type: "int(11)", nullable: false),
                    membroEquipa_idEquipa = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ensaio", x => x.idEnsaio);
                    table.ForeignKey(
                        name: "fk_Ensaio_Lote1",
                        column: x => x.Lote_idLote,
                        principalTable: "lote",
                        principalColumn: "idLote",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Ensaio_Projeto1",
                        column: x => x.Projeto_idProjeto,
                        principalTable: "projeto",
                        principalColumn: "idProjeto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "lote_sub_lote",
                columns: table => new
                {
                    Lote_idLote_prev = table.Column<int>(type: "int(11)", nullable: false),
                    Lote_idLote_atual = table.Column<int>(type: "int(11)", nullable: false),
                    codigoSubLote = table.Column<string>(maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lote_sub_lote", x => new { x.Lote_idLote_prev, x.Lote_idLote_atual });
                    table.ForeignKey(
                        name: "fk_Sub_Lote_Lote2",
                        column: x => x.Lote_idLote_atual,
                        principalTable: "lote",
                        principalColumn: "idLote",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Sub_Lote_Lote1",
                        column: x => x.Lote_idLote_prev,
                        principalTable: "lote",
                        principalColumn: "idLote",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "tanque",
                columns: table => new
                {
                    idTanque = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    nroAnimais = table.Column<int>(type: "int(11)", nullable: false),
                    sala = table.Column<string>(maxLength: 15, nullable: false),
                    observacoes = table.Column<string>(maxLength: 45, nullable: true),
                    Lote_idLote = table.Column<int>(type: "int(11)", nullable: false),
                    Circuito_Tanque_idCircuito = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tanque", x => x.idTanque);
                    table.ForeignKey(
                        name: "fk_Tanque_Circuito_Tanque1",
                        column: x => x.Circuito_Tanque_idCircuito,
                        principalTable: "circuito_tanque",
                        principalColumn: "idCircuito",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Tanque_Lote1",
                        column: x => x.Lote_idLote,
                        principalTable: "lote",
                        principalColumn: "idLote",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reg_alimentar",
                columns: table => new
                {
                    idRegAlim = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Peso = table.Column<float>(nullable: false),
                    Sobras = table.Column<float>(nullable: true),
                    Plano_Alimentar_idPlanAlim = table.Column<int>(type: "int(11)", nullable: false),
                    Tanque_idTanque = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reg_alimentar", x => x.idRegAlim);
                    table.ForeignKey(
                        name: "fk_Reg_Alimentar_Plano_Alimentar1",
                        column: x => x.Plano_Alimentar_idPlanAlim,
                        principalTable: "plano_alimentar",
                        principalColumn: "idPlanAlim",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Reg_Alimentar_Tanque1",
                        column: x => x.Tanque_idTanque,
                        principalTable: "tanque",
                        principalColumn: "idTanque",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reg_amostragens",
                columns: table => new
                {
                    idRegAmo = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(type: "datetime", nullable: false),
                    pesoMedio = table.Column<float>(nullable: false),
                    nroIndividuos = table.Column<int>(type: "int(11)", nullable: false),
                    pesoTotal = table.Column<float>(nullable: false),
                    Tanque_idTanque = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reg_amostragens", x => x.idRegAmo);
                    table.ForeignKey(
                        name: "fk_Reg_Amostragens_Tanque1",
                        column: x => x.Tanque_idTanque,
                        principalTable: "tanque",
                        principalColumn: "idTanque",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reg_manutencao",
                columns: table => new
                {
                    idRegMan = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tipo_Manuntecao_idT_Manutencao = table.Column<int>(type: "int(11)", nullable: false),
                    Tanque_idTanque = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reg_manutencao", x => x.idRegMan);
                    table.ForeignKey(
                        name: "fk_Reg_Manutencao_Tanque1",
                        column: x => x.Tanque_idTanque,
                        principalTable: "tanque",
                        principalColumn: "idTanque",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Reg_Manutencao_Tipo_Manuntecao1",
                        column: x => x.Tipo_Manuntecao_idT_Manutencao,
                        principalTable: "tipo_manuntecao",
                        principalColumn: "idT_Manutencao",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reg_remocoes",
                columns: table => new
                {
                    idRegRemo = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    nroRemoções = table.Column<int>(type: "int(11)", nullable: true),
                    Motivo_idMotivo = table.Column<int>(type: "int(11)", nullable: false),
                    causaMorte = table.Column<string>(type: "char(1)", nullable: true),
                    Tanque_idTanque = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reg_remocoes", x => x.idRegRemo);
                    table.ForeignKey(
                        name: "fk_Reg_Remocoes_Motivo1",
                        column: x => x.Motivo_idMotivo,
                        principalTable: "motivo",
                        principalColumn: "idMotivo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Reg_Remocoes_Tanque1",
                        column: x => x.Tanque_idTanque,
                        principalTable: "tanque",
                        principalColumn: "idTanque",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reg_tratamento",
                columns: table => new
                {
                    idRegTra = table.Column<int>(type: "int(11)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Tempo = table.Column<int>(type: "int(11)", nullable: false),
                    Concentracao = table.Column<float>(nullable: false),
                    Finalidade_idFinalidade = table.Column<int>(type: "int(11)", nullable: false),
                    agente_Trat_idAgenTra = table.Column<int>(type: "int(11)", nullable: false),
                    concAgenTra = table.Column<int>(type: "int(11)", nullable: true),
                    Tanque_idTanque = table.Column<int>(type: "int(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reg_tratamento", x => x.idRegTra);
                    table.ForeignKey(
                        name: "fk_Reg_Tratamento_agente_Trat1",
                        column: x => x.agente_Trat_idAgenTra,
                        principalTable: "agente_trat",
                        principalColumn: "idAgenTra",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Reg_Tratamento_Finalidade1",
                        column: x => x.Finalidade_idFinalidade,
                        principalTable: "finalidade",
                        principalColumn: "idFinalidade",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_Reg_Tratamento_Tanque1",
                        column: x => x.Tanque_idTanque,
                        principalTable: "tanque",
                        principalColumn: "idTanque",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_IdFuncionario",
                table: "AspNetUsers",
                column: "IdFuncionario");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "fk_Circuito_Tanque_Projeto1_idx",
                table: "circuito_tanque",
                column: "Projeto_idProjeto");

            migrationBuilder.CreateIndex(
                name: "fk_Concelho_Distrito1_idx",
                table: "concelho",
                column: "Distrito_id");

            migrationBuilder.CreateIndex(
                name: "fk_equipaProjeto_Funcionario1",
                table: "elementoequipa",
                column: "Funcionario_idFuncionario");

            migrationBuilder.CreateIndex(
                name: "fk_equipaProjeto_Projeto1",
                table: "elementoequipa",
                column: "Projeto_idProjeto");

            migrationBuilder.CreateIndex(
                name: "fk_Ensaio_Lote1",
                table: "ensaio",
                column: "Lote_idLote");

            migrationBuilder.CreateIndex(
                name: "fk_Ensaio_Projeto1",
                table: "ensaio",
                column: "Projeto_idProjeto");

            migrationBuilder.CreateIndex(
                name: "fk_Especie_Familia1_idx",
                table: "especie",
                column: "Familia_idFamilia");

            migrationBuilder.CreateIndex(
                name: "fk_Especie_Grupo1_idx",
                table: "especie",
                column: "Grupo_idGrupo");

            migrationBuilder.CreateIndex(
                name: "fk_Familia_Grupo1_idx",
                table: "familia",
                column: "Grupo_idGrupo");

            migrationBuilder.CreateIndex(
                name: "fk_LocalCaptura_Concelho1_idx",
                table: "localcaptura",
                column: "Concelho_id");

            migrationBuilder.CreateIndex(
                name: "fk_LocalCaptura_Distrito1",
                table: "localcaptura",
                column: "Distrito_id");

            migrationBuilder.CreateIndex(
                name: "fk_Lote_Funcionario1_idx",
                table: "lote",
                column: "Funcionario_idFuncionario");

            migrationBuilder.CreateIndex(
                name: "fk_Lote_Reg_Novos_Animais1_idx",
                table: "lote",
                column: "Reg_Novos_Animais_idRegAnimal");

            migrationBuilder.CreateIndex(
                name: "fk_Sub_Lote_Lote2_idx",
                table: "lote_sub_lote",
                column: "Lote_idLote_atual");

            migrationBuilder.CreateIndex(
                name: "fk_Sub_Lote_Lote1_idx",
                table: "lote_sub_lote",
                column: "Lote_idLote_prev");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Alimentar_Plano_Alimentar1",
                table: "reg_alimentar",
                column: "Plano_Alimentar_idPlanAlim");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Alimentar_Tanque1",
                table: "reg_alimentar",
                column: "Tanque_idTanque");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Amostragens_Tanque1",
                table: "reg_amostragens",
                column: "Tanque_idTanque");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Cond_Amb_Circuito_Tanque1",
                table: "reg_cond_amb",
                column: "Circuito_Tanque_idCircuito");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Manutencao_Tanque1",
                table: "reg_manutencao",
                column: "Tanque_idTanque");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Manutencao_Tipo_Manuntecao1",
                table: "reg_manutencao",
                column: "Tipo_Manuntecao_idT_Manutencao");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Novos_Animais_Especie1",
                table: "reg_novos_animais",
                column: "Especie_idEspecie");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Novos_Animais_Fornecedor1",
                table: "reg_novos_animais",
                column: "Fornecedor_idFornColect");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Novos_Animais_Funcionario1",
                table: "reg_novos_animais",
                column: "Funcionario_idFuncionario");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Novos_Animais_Funcionario2",
                table: "reg_novos_animais",
                column: "Funcionario_idFuncionario1");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Novos_Animais_LocalCaptura1",
                table: "reg_novos_animais",
                column: "LocalCaptura_idLocalCaptura");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Novos_Animais_T_Origem1",
                table: "reg_novos_animais",
                column: "T_Origem_idT_Origem");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Novos_Animais_TipoEstatutoGenetico1",
                table: "reg_novos_animais",
                column: "TipoEstatutoGenetico_idTipoEstatutoGenetico");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Remocoes_Motivo1",
                table: "reg_remocoes",
                column: "Motivo_idMotivo");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Remocoes_Tanque1",
                table: "reg_remocoes",
                column: "Tanque_idTanque");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Tratamento_agente_Trat1",
                table: "reg_tratamento",
                column: "agente_Trat_idAgenTra");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Tratamento_Finalidade1",
                table: "reg_tratamento",
                column: "Finalidade_idFinalidade");

            migrationBuilder.CreateIndex(
                name: "fk_Reg_Tratamento_Tanque1",
                table: "reg_tratamento",
                column: "Tanque_idTanque");

            migrationBuilder.CreateIndex(
                name: "fk_Tanque_Circuito_Tanque1_idx",
                table: "tanque",
                column: "Circuito_Tanque_idCircuito");

            migrationBuilder.CreateIndex(
                name: "fk_Tanque_Lote1_idx",
                table: "tanque",
                column: "Lote_idLote");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "elementoequipa");

            migrationBuilder.DropTable(
                name: "ensaio");

            migrationBuilder.DropTable(
                name: "lote_sub_lote");

            migrationBuilder.DropTable(
                name: "reg_alimentar");

            migrationBuilder.DropTable(
                name: "reg_amostragens");

            migrationBuilder.DropTable(
                name: "reg_cond_amb");

            migrationBuilder.DropTable(
                name: "reg_manutencao");

            migrationBuilder.DropTable(
                name: "reg_remocoes");

            migrationBuilder.DropTable(
                name: "reg_tratamento");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "plano_alimentar");

            migrationBuilder.DropTable(
                name: "tipo_manuntecao");

            migrationBuilder.DropTable(
                name: "motivo");

            migrationBuilder.DropTable(
                name: "agente_trat");

            migrationBuilder.DropTable(
                name: "finalidade");

            migrationBuilder.DropTable(
                name: "tanque");

            migrationBuilder.DropTable(
                name: "circuito_tanque");

            migrationBuilder.DropTable(
                name: "lote");

            migrationBuilder.DropTable(
                name: "projeto");

            migrationBuilder.DropTable(
                name: "reg_novos_animais");

            migrationBuilder.DropTable(
                name: "especie");

            migrationBuilder.DropTable(
                name: "fornecedorcolector");

            migrationBuilder.DropTable(
                name: "funcionario");

            migrationBuilder.DropTable(
                name: "localcaptura");

            migrationBuilder.DropTable(
                name: "t_origem");

            migrationBuilder.DropTable(
                name: "tipoestatutogenetico");

            migrationBuilder.DropTable(
                name: "familia");

            migrationBuilder.DropTable(
                name: "concelho");

            migrationBuilder.DropTable(
                name: "grupo");

            migrationBuilder.DropTable(
                name: "distrito");
        }
    }
}
