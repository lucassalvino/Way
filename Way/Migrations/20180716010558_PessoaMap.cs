using Microsoft.EntityFrameworkCore.Migrations;

namespace Way.Migrations
{
    public partial class PessoaMap : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_MapPessoa_PessoaID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_MapPessoa_InstituicaoID",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MapPessoa",
                table: "MapPessoa");

            migrationBuilder.RenameTable(
                name: "MapPessoa",
                newName: "Pessoas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_Pessoas_PessoaID",
                table: "Emails",
                column: "PessoaID",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Pessoas_InstituicaoID",
                table: "Usuarios",
                column: "InstituicaoID",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Emails_Pessoas_PessoaID",
                table: "Emails");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Pessoas_InstituicaoID",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pessoas",
                table: "Pessoas");

            migrationBuilder.RenameTable(
                name: "Pessoas",
                newName: "MapPessoa");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MapPessoa",
                table: "MapPessoa",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Emails_MapPessoa_PessoaID",
                table: "Emails",
                column: "PessoaID",
                principalTable: "MapPessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_MapPessoa_InstituicaoID",
                table: "Usuarios",
                column: "InstituicaoID",
                principalTable: "MapPessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
