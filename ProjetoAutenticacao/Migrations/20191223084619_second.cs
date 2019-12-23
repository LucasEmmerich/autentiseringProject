using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAutenticacao.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Autenticacao");

            migrationBuilder.CreateTable(
                name: "TAplicativoSet",
                schema: "Autenticacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Aplicativo = table.Column<string>(nullable: false),
                    AppId = table.Column<string>(nullable: false),
                    Excluido = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TAplicativoSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TEmpresaSet",
                schema: "Autenticacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RazaoSocial = table.Column<string>(nullable: false),
                    CNPJ = table.Column<string>(nullable: false),
                    Excluido = table.Column<sbyte>(type: "TINYINT", nullable: false, defaultValue: (sbyte)0),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEmpresaSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TPessoaSet",
                schema: "Autenticacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Telefone = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    CpfCnpj = table.Column<string>(nullable: false),
                    Excluido = table.Column<sbyte>(type: "TINYINT", nullable: false, defaultValue: (sbyte)0),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TPessoaSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TTokenSet",
                schema: "Autenticacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(nullable: false),
                    Validade = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TTokenSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TUserSet",
                schema: "Autenticacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Login = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Pessoa_Id = table.Column<int>(nullable: false),
                    Excluido = table.Column<sbyte>(type: "TINYINT", nullable: false, defaultValue: (sbyte)0),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUserSet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TUserSet_TPessoaSet_Pessoa_Id",
                        column: x => x.Pessoa_Id,
                        principalSchema: "Autenticacao",
                        principalTable: "TPessoaSet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TUserSet_Pessoa_Id",
                schema: "Autenticacao",
                table: "TUserSet",
                column: "Pessoa_Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TAplicativoSet",
                schema: "Autenticacao");

            migrationBuilder.DropTable(
                name: "TEmpresaSet",
                schema: "Autenticacao");

            migrationBuilder.DropTable(
                name: "TTokenSet",
                schema: "Autenticacao");

            migrationBuilder.DropTable(
                name: "TUserSet",
                schema: "Autenticacao");

            migrationBuilder.DropTable(
                name: "TPessoaSet",
                schema: "Autenticacao");
        }
    }
}
