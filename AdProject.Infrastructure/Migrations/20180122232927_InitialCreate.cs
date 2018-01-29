using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AdProject.Infraestrutura.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Announcements",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Price = table.Column<decimal>(nullable: false),
                    PricePrevious = table.Column<decimal>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_CATEGORIES",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    NAME = table.Column<string>(type: "VARCHAR(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_CATEGORIES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ROLES",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ROLES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USERS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
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
                    table.PrimaryKey("PK_TBL_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CountryId = table.Column<int>(nullable: true),
                    IdCountry = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                    table.ForeignKey(
                        name: "FK_States_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBL_SUBCATEGORIES",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "BIGINT", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdCategory = table.Column<long>(nullable: false),
                    VARCHAR300 = table.Column<string>(name: "VARCHAR(300)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_SUBCATEGORIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBL_SUBCATEGORIES_TBL_CATEGORIES_IdCategory",
                        column: x => x.IdCategory,
                        principalSchema: "dbo",
                        principalTable: "TBL_CATEGORIES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_ROLE_CLAIMS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_ROLE_CLAIMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_ROLE_CLAIMS_TBL_ROLES_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "TBL_ROLES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_PROFILES",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<long>(type: "BIGINT", nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_PROFILES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TBL_PROFILES_TBL_USERS_ID",
                        column: x => x.ID,
                        principalSchema: "dbo",
                        principalTable: "TBL_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USER_CLAIMS",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true),
                    UserId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USER_CLAIMS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBL_USER_CLAIMS_TBL_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USER_LOGINS",
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
                    table.PrimaryKey("PK_TBL_USER_LOGINS", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_TBL_USER_LOGINS_TBL_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USER_ROLES",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<long>(nullable: false),
                    RoleId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBL_USER_ROLES", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_TBL_USER_ROLES_TBL_ROLES_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "TBL_ROLES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TBL_USER_ROLES_TBL_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TBL_USER_TOKENS",
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
                    table.PrimaryKey("PK_TBL_USER_TOKENS", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_TBL_USER_TOKENS_TBL_USERS_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "TBL_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdState = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    StateId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_States_CountryId",
                table: "States",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_ROLE_CLAIMS_RoleId",
                schema: "dbo",
                table: "TBL_ROLE_CLAIMS",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "TBL_ROLES",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_SUBCATEGORIES_IdCategory",
                schema: "dbo",
                table: "TBL_SUBCATEGORIES",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USER_CLAIMS_UserId",
                schema: "dbo",
                table: "TBL_USER_CLAIMS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USER_LOGINS_UserId",
                schema: "dbo",
                table: "TBL_USER_LOGINS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TBL_USER_ROLES_RoleId",
                schema: "dbo",
                table: "TBL_USER_ROLES",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "TBL_USERS",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "TBL_USERS",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcements");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "TBL_PROFILES",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_ROLE_CLAIMS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_SUBCATEGORIES",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_USER_CLAIMS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_USER_LOGINS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_USER_ROLES",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_USER_TOKENS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropTable(
                name: "TBL_CATEGORIES",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_ROLES",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TBL_USERS",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
