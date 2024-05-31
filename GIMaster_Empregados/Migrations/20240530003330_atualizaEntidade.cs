using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GIMaster_Empregados.Migrations
{
    public partial class atualizaEntidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataExclusao",
                table: "tbEmpregado");

            migrationBuilder.DropColumn(
                name: "DataInclusao",
                table: "tbEmpregado");

            migrationBuilder.DropColumn(
                name: "UsuarioExclusao",
                table: "tbEmpregado");

            migrationBuilder.DropColumn(
                name: "UsuarioInclusao",
                table: "tbEmpregado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataExclusao",
                table: "tbEmpregado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInclusao",
                table: "tbEmpregado",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UsuarioExclusao",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsuarioInclusao",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
