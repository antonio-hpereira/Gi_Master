using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GIMaster_Empregados.Migrations
{
    public partial class atualizaEntidade3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UniqueKey",
                table: "tbEmpregado");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "tbEmpregado",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UniqueKey",
                table: "tbEmpregado",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
