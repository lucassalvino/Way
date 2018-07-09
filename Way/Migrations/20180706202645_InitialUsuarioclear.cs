using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Way.Migrations
{
    public partial class InitialUsuarioclear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Login = table.Column<string>(maxLength: 64, nullable: false),
                    Senha = table.Column<string>(maxLength: 64, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SessaoUsuario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    UsuarioID = table.Column<Guid>(nullable: false),
                    DataInicioSessao = table.Column<DateTimeOffset>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessaoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessaoUsuario_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SessaoUsuario_UsuarioID",
                table: "SessaoUsuario",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SessaoUsuario");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
