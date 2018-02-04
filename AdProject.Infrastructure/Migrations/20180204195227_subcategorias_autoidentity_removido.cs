using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdProject.Infraestrutura.Migrations
{
    public partial class subcategorias_autoidentity_removido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "TBL_SUBCATEGORIAS",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "TBL_CATEGORIAS",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "TBL_SUBCATEGORIAS",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                schema: "dbo",
                table: "TBL_CATEGORIAS",
                type: "INT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INT")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);
        }
    }
}
