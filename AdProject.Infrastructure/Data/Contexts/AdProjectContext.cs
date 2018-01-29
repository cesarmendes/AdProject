using AdProject.Dominio.Entidades;
using AdProject.Infraestrutura.Data.Contexts.Configurations;
using AdProject.Infraestrutura.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.Data.Contexts
{
    public class AdProjectContext : IdentityDbContext<AppUser, AppRole, long, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public static readonly string SCHEME_NAME = "dbo";
        public static readonly string TYPE_INT = "INT";
        public static readonly string TYPE_BIGINT = "BIGINT";
        public static readonly string TYPE_DECIMAL = "DECIMAL";
        public static readonly string TYPE_BOOL = "BIT";
        public static readonly string TYPE_STRING = "VARCHAR";
        public static readonly string TYPE_TEXT = "TEXT";


        public AdProjectContext()
            : base()
        {

        }
        public AdProjectContext(DbContextOptions<AdProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Anuncio> Adverts { get; set; }
        public DbSet<Categoria> Categories { get; set; }
        public DbSet<Cidade> Cities { get; set; }
        public DbSet<Pais> Countries { get; set; }
        public DbSet<Perfil> Profiles { get; set; }
        public DbSet<Estado> States { get; set; }
        public DbSet<SubCategoria> SubCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration<Categoria>(new CategoryConfig());
            builder.ApplyConfiguration<Perfil>(new ProfileConfig());
            builder.ApplyConfiguration<SubCategoria>(new SubCategoryConfig());


            //Asp.Net Identity configuration
            builder.ApplyConfiguration<AppRoleClaim>(new AppRoleClaimConfig());
            builder.ApplyConfiguration<AppUserClaim>(new AppUserClaimConfig());
            builder.ApplyConfiguration<AppUserLogin>(new AppUserLoginConfig());
            builder.ApplyConfiguration<AppUserRole>(new AppUserRoleConfig());
            builder.ApplyConfiguration<AppUserToken>(new AppUserTokenConfig());
            builder.ApplyConfiguration<AppRole>(new AppRoleConfig());
            builder.ApplyConfiguration<AppUser>(new AppUserConfig());
        }
    }
}
