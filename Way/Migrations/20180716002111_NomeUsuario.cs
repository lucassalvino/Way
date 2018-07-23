using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Way.Migrations
{
    public partial class NomeUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Documentos_MapPessoa_PessoaID",
                table: "Documentos");

            migrationBuilder.DropIndex(
                name: "IX_Documentos_PessoaID",
                table: "Documentos");

            migrationBuilder.DropColumn(
                name: "PessoaID",
                table: "Documentos");

            migrationBuilder.AddColumn<Guid>(
                name: "InstituicaoID",
                table: "Usuarios",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Usuarios",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_InstituicaoID",
                table: "Usuarios",
                column: "InstituicaoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_MapPessoa_InstituicaoID",
                table: "Usuarios",
                column: "InstituicaoID",
                principalTable: "MapPessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_MapPessoa_InstituicaoID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_InstituicaoID",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "InstituicaoID",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Usuarios");

            migrationBuilder.AddColumn<Guid>(
                name: "PessoaID",
                table: "Documentos",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_PessoaID",
                table: "Documentos",
                column: "PessoaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Documentos_MapPessoa_PessoaID",
                table: "Documentos",
                column: "PessoaID",
                principalTable: "MapPessoa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
