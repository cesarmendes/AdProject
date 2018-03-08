﻿// <auto-generated />
using AdProject.Infraestrutura.BancoDados.Contextos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace AdProject.Infraestrutura.Migrations
{
    [DbContext(typeof(AdProjectContext))]
    [Migration("20180207001115_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("AdProject.Dominio.Entidades.Anuncio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("BIGINT");

                    b.Property<DateTime>("Data")
                        .HasColumnName("DATA")
                        .HasColumnType("TIMESTAMP");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnName("DESCRICAO")
                        .HasColumnType("VARCHAR(1000)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnName("TITULO")
                        .HasColumnType("VARCHAR(200)");

                    b.Property<decimal>("Valor")
                        .HasColumnName("VALOR")
                        .HasColumnType("DECIMAL");

                    b.Property<decimal?>("ValorAnterior")
                        .HasColumnName("VALOR_ANTERIOR")
                        .HasColumnType("DECIMAL");

                    b.HasKey("Id");

                    b.ToTable("TBL_ANUNCIOS","dbo");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("INT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.ToTable("TBL_CATEGORIAS","dbo");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("INT");

                    b.Property<int>("IdEstado")
                        .HasColumnName("ID_ESTADO")
                        .HasColumnType("INT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("IdEstado");

                    b.ToTable("TBL_CIDADES","dbo");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Estado", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("INT");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("CODIGO")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(2);

                    b.Property<int>("IdPais")
                        .HasColumnName("ID_PAIS")
                        .HasColumnType("INT");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("IdPais");

                    b.ToTable("TBL_ESTADOS","dbo");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Pais", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("INT");

                    b.Property<string>("Codigo")
                        .IsRequired()
                        .HasColumnName("CODIGO")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(3);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NOME")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("TBL_PAISES","dbo");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Perfil", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("TBL_PEFIS","dbo");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Subcategoria", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("INT");

                    b.Property<int>("IdCategoria");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasColumnType("VARCHAR")
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("IdCategoria");

                    b.ToTable("TBL_SUBCATEGORIAS","dbo");
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("TBL_PAPEIS","dbo");
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppRoleClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("TBL_PAPEIS_DIREITOS","dbo");
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("TBL_USUARIOS","dbo");
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUserClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("TBL_USUARIO_DIREITOS","dbo");
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("TBL_USUARIO_LOGINS","dbo");
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUserRole", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("TBL_USUARIO_PAPEIS","dbo");
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUserToken", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("TBL_USUARIO_TOKENS","dbo");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Cidade", b =>
                {
                    b.HasOne("AdProject.Dominio.Entidades.Estado", "Estado")
                        .WithMany("Cidades")
                        .HasForeignKey("IdEstado")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Estado", b =>
                {
                    b.HasOne("AdProject.Dominio.Entidades.Pais", "Pais")
                        .WithMany("Estados")
                        .HasForeignKey("IdPais")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Perfil", b =>
                {
                    b.HasOne("AdProject.Infraestrutura.Identity.AppUser")
                        .WithOne("Profile")
                        .HasForeignKey("AdProject.Dominio.Entidades.Perfil", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Subcategoria", b =>
                {
                    b.HasOne("AdProject.Dominio.Entidades.Categoria", "Categoria")
                        .WithMany("SubCategorias")
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppRoleClaim", b =>
                {
                    b.HasOne("AdProject.Infraestrutura.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUserClaim", b =>
                {
                    b.HasOne("AdProject.Infraestrutura.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUserLogin", b =>
                {
                    b.HasOne("AdProject.Infraestrutura.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUserRole", b =>
                {
                    b.HasOne("AdProject.Infraestrutura.Identity.AppRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AdProject.Infraestrutura.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUserToken", b =>
                {
                    b.HasOne("AdProject.Infraestrutura.Identity.AppUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}