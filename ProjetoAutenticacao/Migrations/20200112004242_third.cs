using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoAutenticacao.Migrations
{
    public partial class third : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TUserSet_TPessoaSet_Pessoa_Id",
                schema: "Autenticacao",
                table: "TUserSet");

            migrationBuilder.DropIndex(
                name: "IX_TUserSet_Pessoa_Id",
                schema: "Autenticacao",
                table: "TUserSet");

            migrationBuilder.AddForeignKey(
                name: "FK_TPessoaSet_TUserSet_Id",
                schema: "Autenticacao",
                table: "TPessoaSet",
                column: "Id",
                principalSchema: "Autenticacao",
                principalTable: "TUserSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TPessoaSet_TUserSet_Id",
                schema: "Autenticacao",
                table: "TPessoaSet");

            migrationBuilder.CreateIndex(
                name: "IX_TUserSet_Pessoa_Id",
                schema: "Autenticacao",
                table: "TUserSet",
                column: "Pessoa_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TUserSet_TPessoaSet_Pessoa_Id",
                schema: "Autenticacao",
                table: "TUserSet",
                column: "Pessoa_Id",
                principalSchema: "Autenticacao",
                principalTable: "TPessoaSet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
