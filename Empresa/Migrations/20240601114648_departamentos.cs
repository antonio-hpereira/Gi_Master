using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GIMaster_Empresa.Migrations
{
    public partial class departamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbDepartamentos",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Pai = table.Column<int>(type: "int", nullable: false),
                    PaiID = table.Column<int>(type: "int", nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UltimaAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataUltimaAlteracao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbDepartamentos", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbDepartamentos");
        }
    }
}
