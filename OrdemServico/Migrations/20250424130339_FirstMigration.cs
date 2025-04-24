using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrdemServico.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    idCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeCliente = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Clientes__885457EE011734EE", x => x.idCliente);
                });

            migrationBuilder.CreateTable(
                name: "Defeitos",
                columns: table => new
                {
                    idDefeito = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Defeitos__9549F9F7BD729DE1", x => x.idDefeito);
                });

            migrationBuilder.CreateTable(
                name: "Equipamentos",
                columns: table => new
                {
                    idEquipamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeEquipamento = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Equipame__75940D34D0CF45D2", x => x.idEquipamento);
                });

            migrationBuilder.CreateTable(
                name: "Tecnicos",
                columns: table => new
                {
                    idTecnico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeTecnico = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Tecnicos__295BEDE46571E492", x => x.idTecnico);
                });

            migrationBuilder.CreateTable(
                name: "OrdensServicos",
                columns: table => new
                {
                    idOrdemServico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dataOrdemServico = table.Column<DateTime>(type: "date", nullable: false),
                    servico = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    valorTotal = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    statusServico = table.Column<int>(type: "int", unicode: false, maxLength: 30, nullable: false),
                    IdEquipamento = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false),
                    IdDefeito = table.Column<int>(type: "int", nullable: false),
                    IdTecnico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__OrdensSe__976593105C89ACCE", x => x.idOrdemServico);
                    table.ForeignKey(
                        name: "FK__OrdensSer__idCli__4222D4EF",
                        column: x => x.IdCliente,
                        principalTable: "Clientes",
                        principalColumn: "idCliente",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__OrdensSer__idDef__4316F928",
                        column: x => x.IdDefeito,
                        principalTable: "Defeitos",
                        principalColumn: "idDefeito",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__OrdensSer__idEqu__412EB0B6",
                        column: x => x.IdEquipamento,
                        principalTable: "Equipamentos",
                        principalColumn: "idEquipamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__OrdensSer__idTec__440B1D61",
                        column: x => x.IdTecnico,
                        principalTable: "Tecnicos",
                        principalColumn: "idTecnico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServicos_IdCliente",
                table: "OrdensServicos",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServicos_IdDefeito",
                table: "OrdensServicos",
                column: "IdDefeito");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServicos_IdEquipamento",
                table: "OrdensServicos",
                column: "IdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_OrdensServicos_IdTecnico",
                table: "OrdensServicos",
                column: "IdTecnico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdensServicos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Defeitos");

            migrationBuilder.DropTable(
                name: "Equipamentos");

            migrationBuilder.DropTable(
                name: "Tecnicos");
        }
    }
}
