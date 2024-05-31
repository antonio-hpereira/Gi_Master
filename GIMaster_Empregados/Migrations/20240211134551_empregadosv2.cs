using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GIMaster_Empregados.Migrations
{
    public partial class empregadosv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Cidade",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Rua",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "tbEmpregado");

            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "tbEmpregado");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "tbEmpregado");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "tbEmpregado");

            migrationBuilder.DropColumn(
                name: "Rua",
                table: "tbEmpregado");

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "tbEmpregado");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "tbEmpregado",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
