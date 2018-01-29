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
    partial class AdProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AdProject.Dominio.Entidades.Announcement", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Price");

                    b.Property<decimal?>("PricePrevious");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Announcements");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("NAME")
                        .HasColumnType("VARCHAR(300)");

                    b.HasKey("Id");

                    b.ToTable("TBL_CATEGORIES","dbo");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("IdState");

                    b.Property<string>("Name");

                    b.Property<int?>("StateId");

                    b.HasKey("Id");

                    b.HasIndex("StateId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Profile", b =>
                {
                    b.Property<long>("Id")
                        .HasColumnName("ID")
                        .HasColumnType("BIGINT");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("TBL_PROFILES","dbo");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.State", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CountryId");

                    b.Property<int>("IdCountry");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("States");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.SubCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID")
                        .HasColumnType("BIGINT");

                    b.Property<long>("IdCategory");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("VARCHAR(300)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategory");

                    b.ToTable("TBL_SUBCATEGORIES","dbo");
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
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("TBL_ROLES","dbo");
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

                    b.ToTable("TBL_ROLE_CLAIMS","dbo");
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
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("TBL_USERS","dbo");
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

                    b.ToTable("TBL_USER_CLAIMS","dbo");
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUserLogin", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<long>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("TBL_USER_LOGINS","dbo");
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUserRole", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<long>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("TBL_USER_ROLES","dbo");
                });

            modelBuilder.Entity("AdProject.Infraestrutura.Identity.AppUserToken", b =>
                {
                    b.Property<long>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("TBL_USER_TOKENS","dbo");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.City", b =>
                {
                    b.HasOne("AdProject.Dominio.Entidades.State", "State")
                        .WithMany("Cities")
                        .HasForeignKey("StateId");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.Profile", b =>
                {
                    b.HasOne("AdProject.Infraestrutura.Identity.AppUser")
                        .WithOne("Profile")
                        .HasForeignKey("AdProject.Dominio.Entidades.Profile", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.State", b =>
                {
                    b.HasOne("AdProject.Dominio.Entidades.Country", "Country")
                        .WithMany("States")
                        .HasForeignKey("CountryId");
                });

            modelBuilder.Entity("AdProject.Dominio.Entidades.SubCategory", b =>
                {
                    b.HasOne("AdProject.Dominio.Entidades.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("IdCategory")
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
