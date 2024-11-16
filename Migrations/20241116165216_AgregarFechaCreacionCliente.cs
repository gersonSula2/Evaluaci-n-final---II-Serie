using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace clienteAPI_EF.Migrations
{
    /// <inheritdoc />
    public partial class AgregarFechaCreacionCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformacionClientes_Clientes_ClienteID",
                table: "InformacionClientes");

            migrationBuilder.RenameColumn(
                name: "ClienteID",
                table: "InformacionClientes",
                newName: "ClienteId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "InformacionClientes",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_InformacionClientes_ClienteID",
                table: "InformacionClientes",
                newName: "IX_InformacionClientes_ClienteId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Clientes",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId1",
                table: "InformacionClientes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaCreacion",
                table: "Clientes",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_InformacionClientes_ClienteId1",
                table: "InformacionClientes",
                column: "ClienteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_InformacionClientes_Clientes_ClienteId",
                table: "InformacionClientes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InformacionClientes_Clientes_ClienteId1",
                table: "InformacionClientes",
                column: "ClienteId1",
                principalTable: "Clientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InformacionClientes_Clientes_ClienteId",
                table: "InformacionClientes");

            migrationBuilder.DropForeignKey(
                name: "FK_InformacionClientes_Clientes_ClienteId1",
                table: "InformacionClientes");

            migrationBuilder.DropIndex(
                name: "IX_InformacionClientes_ClienteId1",
                table: "InformacionClientes");

            migrationBuilder.DropColumn(
                name: "ClienteId1",
                table: "InformacionClientes");

            migrationBuilder.DropColumn(
                name: "FechaCreacion",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "ClienteId",
                table: "InformacionClientes",
                newName: "ClienteID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "InformacionClientes",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_InformacionClientes_ClienteId",
                table: "InformacionClientes",
                newName: "IX_InformacionClientes_ClienteID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Clientes",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_InformacionClientes_Clientes_ClienteID",
                table: "InformacionClientes",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
