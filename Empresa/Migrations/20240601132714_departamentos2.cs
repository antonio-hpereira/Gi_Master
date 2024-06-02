using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GIMaster_Empresa.Migrations
{
    public partial class departamentos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EmpresaID",
                table: "tbDepartamentos",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmpresaID",
                table: "tbDepartamentos");
        }
    }
}
