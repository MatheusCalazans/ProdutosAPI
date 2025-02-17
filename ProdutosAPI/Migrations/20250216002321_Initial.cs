using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdutosAPI.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CATEGORIAS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CATEGORIAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PRODUTOS",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PRECO = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    CATEGORIAID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PRODUTOS_CATEGORIAS_CATEGORIAID",
                        column: x => x.CATEGORIAID,
                        principalTable: "CATEGORIAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CATEGORIAS_NOME",
                table: "CATEGORIAS",
                column: "NOME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PRODUTOS_CATEGORIAID",
                table: "PRODUTOS",
                column: "CATEGORIAID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PRODUTOS");

            migrationBuilder.DropTable(
                name: "CATEGORIAS");
        }
    }
}
