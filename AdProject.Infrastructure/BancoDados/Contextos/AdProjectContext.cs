using AdProject.Dominio.Entidades;
using AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes;
using AdProject.Infraestrutura.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Contextos
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
        public static readonly string TYPE_DATETIME = "DATETIME";

        public AdProjectContext()
            : base()
        {

        }
        public AdProjectContext(DbContextOptions<AdProjectContext> options)
            : base(options)
        {

        }

        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Perfil> Perfis { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Subcategoria> Subcategorias { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration<Anuncio>(new AnuncioConfig());
            builder.ApplyConfiguration<Categoria>(new CategoriaConfig());
            builder.ApplyConfiguration<Cidade>(new CidadeConfig());
            builder.ApplyConfiguration<Pais>(new PaisConfig());
            builder.ApplyConfiguration<Perfil>(new PerfilConfig());
            builder.ApplyConfiguration<Estado>(new EstadoConfig());
            builder.ApplyConfiguration<Subcategoria>(new SubcategoriaConfig());


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
