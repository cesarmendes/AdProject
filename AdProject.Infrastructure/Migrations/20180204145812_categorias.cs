using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdProject.Infraestrutura.Migrations
{
    public partial class categorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                schema: "dbo",
                table: "TBL_SUBCATEGORIAS",
                type: "VARCHAR",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)");

            migrationBuilder.AlterColumn<int>(
                name: "IdCategoria",
                schema: "dbo",
                table: "TBL_SUBCATEGORIAS",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "TBL_SUBCATEGORIAS",
                type: "INT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                schema: "dbo",
                table: "TBL_CATEGORIAS",
                type: "VARCHAR",
                maxLength: 300,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(300)");

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "TBL_CATEGORIAS",
                type: "INT",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "BIGINT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                schema: "dbo",
                table: "TBL_SUBCATEGORIAS",
                type: "VARCHAR(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<long>(
                name: "IdCategoria",
                schema: "dbo",
                table: "TBL_SUBCATEGORIAS",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "dbo",
                table: "TBL_SUBCATEGORIAS",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                schema: "dbo",
                table: "TBL_CATEGORIAS",
                type: "VARCHAR(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR",
                oldMaxLength: 300);

            migrationBuilder.AlterColumn<long>(
                name: "ID",
                schema: "dbo",
                table: "TBL_CATEGORIAS",
                type: "BIGINT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}
