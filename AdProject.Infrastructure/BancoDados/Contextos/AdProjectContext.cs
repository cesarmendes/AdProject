using AdProject.Dominio.Entidades;
using AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes;
using AdProject.Infraestrutura.BancoDados.Contextos.Tipos;
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
        TiposBaseDados Tipos { get; set; }

        public AdProjectContext(TiposBaseDados tipos)
            : base()
        {
            this.Tipos = tipos;
        }
        public AdProjectContext(DbContextOptions<AdProjectContext> options, TiposBaseDados tipos)
            : base(options)
        {
            this.Tipos = tipos;
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

            builder.ApplyConfiguration<Anuncio>(new AnuncioConfig(Tipos));
            builder.ApplyConfiguration<Categoria>(new CategoriaConfig(Tipos));
            builder.ApplyConfiguration<Cidade>(new CidadeConfig(Tipos));
            builder.ApplyConfiguration<Pais>(new PaisConfig(Tipos));
            builder.ApplyConfiguration<Perfil>(new PerfilConfig(Tipos));
            builder.ApplyConfiguration<Estado>(new EstadoConfig(Tipos));
            builder.ApplyConfiguration<Subcategoria>(new SubcategoriaConfig(Tipos));


            //Asp.Net Identity configuration
            builder.ApplyConfiguration<AppRoleClaim>(new AppRoleClaimConfig(Tipos));
            builder.ApplyConfiguration<AppUserClaim>(new AppUserClaimConfig(Tipos));
            builder.ApplyConfiguration<AppUserLogin>(new AppUserLoginConfig(Tipos));
            builder.ApplyConfiguration<AppUserRole>(new AppUserRoleConfig(Tipos));
            builder.ApplyConfiguration<AppUserToken>(new AppUserTokenConfig(Tipos));
            builder.ApplyConfiguration<AppRole>(new AppRoleConfig(Tipos));
            builder.ApplyConfiguration<AppUser>(new AppUserConfig(Tipos));
        }
    }
}
