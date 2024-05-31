using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GIMaster_Empresa.Migrations
{
    public partial class empresaatualiza01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbEmpresas",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RazaoSocial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fantasia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnpj = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ramo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnae = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFundacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bairro = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rua = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbEmpresas", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbEmpresas");
        }
    }
}
