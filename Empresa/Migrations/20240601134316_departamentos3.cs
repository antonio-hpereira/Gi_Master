using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GIMaster_Empresa.Migrations
{
    public partial class departamentos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sigla",
                table: "tbDepartamentos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sigla",
                table: "tbDepartamentos");
        }
    }
}
