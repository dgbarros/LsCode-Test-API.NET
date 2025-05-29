using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LsCode.API.Migrations
{
    /// <inheritdoc />
    public partial class AjusteDimensoesProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caixas_Dimensoes_DimensoesId",
                table: "Caixas");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Dimensoes_DimensoesId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Dimensoes");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_DimensoesId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Caixas_DimensoesId",
                table: "Caixas");

            migrationBuilder.RenameColumn(
                name: "DimensoesId",
                table: "Produtos",
                newName: "Dimensoes_Largura");

            migrationBuilder.RenameColumn(
                name: "DimensoesId",
                table: "Caixas",
                newName: "Dimensoes_Largura");

            migrationBuilder.AddColumn<int>(
                name: "Dimensoes_Altura",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dimensoes_Comprimento",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dimensoes_Id",
                table: "Produtos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dimensoes_Altura",
                table: "Caixas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dimensoes_Comprimento",
                table: "Caixas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dimensoes_Id",
                table: "Caixas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeCaixa",
                table: "Caixas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dimensoes_Altura",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Dimensoes_Comprimento",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Dimensoes_Id",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "Dimensoes_Altura",
                table: "Caixas");

            migrationBuilder.DropColumn(
                name: "Dimensoes_Comprimento",
                table: "Caixas");

            migrationBuilder.DropColumn(
                name: "Dimensoes_Id",
                table: "Caixas");

            migrationBuilder.DropColumn(
                name: "NomeCaixa",
                table: "Caixas");

            migrationBuilder.RenameColumn(
                name: "Dimensoes_Largura",
                table: "Produtos",
                newName: "DimensoesId");

            migrationBuilder.RenameColumn(
                name: "Dimensoes_Largura",
                table: "Caixas",
                newName: "DimensoesId");

            migrationBuilder.CreateTable(
                name: "Dimensoes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Altura = table.Column<int>(type: "int", nullable: false),
                    Comprimento = table.Column<int>(type: "int", nullable: false),
                    Largura = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dimensoes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_DimensoesId",
                table: "Produtos",
                column: "DimensoesId");

            migrationBuilder.CreateIndex(
                name: "IX_Caixas_DimensoesId",
                table: "Caixas",
                column: "DimensoesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Caixas_Dimensoes_DimensoesId",
                table: "Caixas",
                column: "DimensoesId",
                principalTable: "Dimensoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Dimensoes_DimensoesId",
                table: "Produtos",
                column: "DimensoesId",
                principalTable: "Dimensoes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
