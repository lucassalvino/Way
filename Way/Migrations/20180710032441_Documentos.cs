using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Way.Migrations
{
    public partial class Documentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false),
                    Documento = table.Column<string>(maxLength: 30, nullable: true),
                    TipoDocumentoID = table.Column<Guid>(nullable: false),
                    PessoaID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documentos_MapPessoa_PessoaID",
                        column: x => x.PessoaID,
                        principalTable: "MapPessoa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Documentos_TipoDocumento_TipoDocumentoID",
                        column: x => x.TipoDocumentoID,
                        principalTable: "TipoDocumento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_PessoaID",
                table: "Documentos",
                column: "PessoaID");

            migrationBuilder.CreateIndex(
                name: "IX_Documentos_TipoDocumentoID",
                table: "Documentos",
                column: "TipoDocumentoID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentos");
        }
    }
}
