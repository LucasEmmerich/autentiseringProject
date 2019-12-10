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
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2019, 12, 9, 19, 0, 26, 111, DateTimeKind.Local).AddTicks(2216))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TEmpresaSet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TTokenSet",
                schema: "Autenticacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Token = table.Column<string>(nullable: false),
                    Validade = table.Column<DateTime>(type: "DATETIME", nullable: false)
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
                    Excluido = table.Column<sbyte>(type: "TINYINT", nullable: false, defaultValue: (sbyte)0),
                    DataCriacao = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValue: new DateTime(2019, 12, 9, 19, 0, 26, 97, DateTimeKind.Local).AddTicks(2060))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUserSet", x => x.Id);
                });
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
        }
    }
}
