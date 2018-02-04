using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdProject.Infraestrutura.Migrations
{
    public partial class relacionamentos_estados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_CIDADES_TBL_ESTADOS_EstadoId",
                schema: "dbo",
                table: "TBL_CIDADES");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_ESTADOS_TBL_PAISES_PaisId",
                schema: "dbo",
                table: "TBL_ESTADOS");

            migrationBuilder.DropIndex(
                name: "IX_TBL_ESTADOS_PaisId",
                schema: "dbo",
                table: "TBL_ESTADOS");

            migrationBuilder.DropIndex(
                name: "IX_TBL_CIDADES_EstadoId",
                schema: "dbo",
                table: "TBL_CIDADES");

            migrationBuilder.DropColumn(
                name: "PaisId",
                schema: "dbo",
                table: "TBL_ESTADOS");

            migrationBuilder.DropColumn(
                name: "EstadoId",
                schema: "dbo",
                table: "TBL_CIDADES");

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                schema: "dbo",
                table: "TBL_ESTADOS",
                type: "VARCHAR",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)");

            migrationBuilder.AlterColumn<string>(
                name: "CODIGO",
                schema: "dbo",
                table: "TBL_ESTADOS",
                type: "VARCHAR",
                maxLength: 2,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(2)");

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                schema: "dbo",
                table: "TBL_CIDADES",
                type: "VARCHAR",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ESTADOS_ID_PAIS",
                schema: "dbo",
                table: "TBL_ESTADOS",
                column: "ID_PAIS");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_CIDADES_ID_ESTADO",
                schema: "dbo",
                table: "TBL_CIDADES",
                column: "ID_ESTADO");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_CIDADES_TBL_ESTADOS_ID_ESTADO",
                schema: "dbo",
                table: "TBL_CIDADES",
                column: "ID_ESTADO",
                principalSchema: "dbo",
                principalTable: "TBL_ESTADOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_ESTADOS_TBL_PAISES_ID_PAIS",
                schema: "dbo",
                table: "TBL_ESTADOS",
                column: "ID_PAIS",
                principalSchema: "dbo",
                principalTable: "TBL_PAISES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBL_CIDADES_TBL_ESTADOS_ID_ESTADO",
                schema: "dbo",
                table: "TBL_CIDADES");

            migrationBuilder.DropForeignKey(
                name: "FK_TBL_ESTADOS_TBL_PAISES_ID_PAIS",
                schema: "dbo",
                table: "TBL_ESTADOS");

            migrationBuilder.DropIndex(
                name: "IX_TBL_ESTADOS_ID_PAIS",
                schema: "dbo",
                table: "TBL_ESTADOS");

            migrationBuilder.DropIndex(
                name: "IX_TBL_CIDADES_ID_ESTADO",
                schema: "dbo",
                table: "TBL_CIDADES");

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                schema: "dbo",
                table: "TBL_ESTADOS",
                type: "VARCHAR(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<string>(
                name: "CODIGO",
                schema: "dbo",
                table: "TBL_ESTADOS",
                type: "VARCHAR(2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 2);

            migrationBuilder.AddColumn<int>(
                name: "PaisId",
                schema: "dbo",
                table: "TBL_ESTADOS",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                schema: "dbo",
                table: "TBL_CIDADES",
                type: "VARCHAR(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<int>(
                name: "EstadoId",
                schema: "dbo",
                table: "TBL_CIDADES",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ESTADOS_PaisId",
                schema: "dbo",
                table: "TBL_ESTADOS",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_CIDADES_EstadoId",
                schema: "dbo",
                table: "TBL_CIDADES",
                column: "EstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_CIDADES_TBL_ESTADOS_EstadoId",
                schema: "dbo",
                table: "TBL_CIDADES",
                column: "EstadoId",
                principalSchema: "dbo",
                principalTable: "TBL_ESTADOS",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TBL_ESTADOS_TBL_PAISES_PaisId",
                schema: "dbo",
                table: "TBL_ESTADOS",
                column: "PaisId",
                principalSchema: "dbo",
                principalTable: "TBL_PAISES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
