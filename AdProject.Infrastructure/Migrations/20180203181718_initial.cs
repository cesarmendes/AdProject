using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdProject.Infraestrutura.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "TBL_ANUNCIOS",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    DATA = table.Column<DateTime>(type: "TIMESTAMP", nullable: false),
                    DESCRICAO = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    TITULO = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    VALOR = table.Column<decimal>(type: "DECIMAL", nullable: false),
                    VALOR_ANTERIOR = table.Column<decimal>(type: "DECIMAL", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ANUNCIOS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_CATEGORIAS",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    NOME = table.Column<string>(type: "VARCHAR(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CATEGORIAS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PAISES",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false),
                    CODIGO = table.Column<string>(type: "VARCHAR", maxLength: 3, nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PAISES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PAPEIS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PAPEIS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USUARIOS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USUARIOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_SUBCATEGORIAS",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    IdCategoria = table.Column<long>(nullable: false),
                    NAME = table.Column<string>(type: "VARCHAR(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SUBCATEGORIAS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBL_SUBCATEGORIAS_TBL_CATEGORIAS_IdCategoria",
                        column: x => x.IdCategoria,
                        principalSchema: "dbo",
                        principalTable: "TBL_CATEGORIAS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ESTADOS",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false),
                    CODIGO = table.Column<string>(type: "VARCHAR(2)", nullable: false),
                    ID_PAIS = table.Column<int>(type: "INT", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR(300)", nullable: false),
                    PaisId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ESTADOS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBL_ESTADOS_TBL_PAISES_PaisId",
                        column: x => x.PaisId,
                        principalSchema: "dbo",
                        principalTable: "TBL_PAISES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PAPEIS_DIREITOS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PAPEIS_DIREITOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_PAPEIS_DIREITOS_TBL_PAPEIS_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "TBL_PAPEIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PEFIS",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "BIGINT", nullable: false),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PEFIS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBL_PEFIS_TBL_USUARIOS_ID",
                        column: x => x.ID,
                        principalSchema: "dbo",
                        principalTable: "TBL_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USUARIO_DIREITOS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USUARIO_DIREITOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_USUARIO_DIREITOS_TBL_USUARIOS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USUARIO_LOGINS",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USUARIO_LOGINS", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_TBL_USUARIO_LOGINS_TBL_USUARIOS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USUARIO_PAPEIS",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USUARIO_PAPEIS", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_TBL_USUARIO_PAPEIS_TBL_PAPEIS_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "TBL_PAPEIS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_USUARIO_PAPEIS_TBL_USUARIOS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USUARIO_TOKENS",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USUARIO_TOKENS", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_TBL_USUARIO_TOKENS_TBL_USUARIOS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_USUARIOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_CIDADES",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INT", nullable: false),
                    EstadoId = table.Column<int>(nullable: true),
                    ID_ESTADO = table.Column<int>(type: "INT", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CIDADES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBL_CIDADES_TBL_ESTADOS_EstadoId",
                        column: x => x.EstadoId,
                        principalSchema: "dbo",
                        principalTable: "TBL_ESTADOS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBL_CIDADES_EstadoId",
                schema: "dbo",
                table: "TBL_CIDADES",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ESTADOS_PaisId",
                schema: "dbo",
                table: "TBL_ESTADOS",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "TBL_PAPEIS",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBL_PAPEIS_DIREITOS_RoleId",
                schema: "dbo",
                table: "TBL_PAPEIS_DIREITOS",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SUBCATEGORIAS_IdCategoria",
                schema: "dbo",
                table: "TBL_SUBCATEGORIAS",
                column: "IdCategoria");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USUARIO_DIREITOS_UserId",
                schema: "dbo",
                table: "TBL_USUARIO_DIREITOS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USUARIO_LOGINS_UserId",
                schema: "dbo",
                table: "TBL_USUARIO_LOGINS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USUARIO_PAPEIS_RoleId",
                schema: "dbo",
                table: "TBL_USUARIO_PAPEIS",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "TBL_USUARIOS",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "TBL_USUARIOS",
                column: "NormalizedUserName",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBL_ANUNCIOS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_CIDADES",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_PAPEIS_DIREITOS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_PEFIS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_SUBCATEGORIAS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_USUARIO_DIREITOS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_USUARIO_LOGINS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_USUARIO_PAPEIS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_USUARIO_TOKENS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_ESTADOS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_CATEGORIAS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_PAPEIS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_USUARIOS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_PAISES",
                schema: "dbo");
        }
    }
}
