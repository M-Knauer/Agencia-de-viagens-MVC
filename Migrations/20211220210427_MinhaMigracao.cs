using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodTrip.Migrations
{
    public partial class MinhaMigracao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Id_cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CPF = table.Column<string>(type: "char(11)", nullable: false),
                    Sexo = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Id_cliente);
                });

            migrationBuilder.CreateTable(
                name: "Passagem",
                columns: table => new
                {
                    Id_pass = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    preco = table.Column<decimal>(type: "decimal(7,2)", nullable: false),
                    Embarque = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Desembarque = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Id_cliente_pass = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passagem", x => x.Id_pass);
                    table.ForeignKey(
                        name: "FK_Passagem_Cliente_Id_cliente_pass",
                        column: x => x.Id_cliente_pass,
                        principalTable: "Cliente",
                        principalColumn: "Id_cliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passagem_Id_cliente_pass",
                table: "Passagem",
                column: "Id_cliente_pass");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passagem");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
