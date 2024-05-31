using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GIMaster_Empregados.Migrations
{
    public partial class atualizaEmp01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "tbEmpregado");
        }
    }
}
