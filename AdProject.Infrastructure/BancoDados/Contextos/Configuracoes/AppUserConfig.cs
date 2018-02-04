using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Dominio.Entidades;
using AdProject.Infraestrutura.Identity;
using AdProject.Infraestrutura.BancoDados.Contextos.Tipos;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        TiposBaseDados Tipos { get; set; }

        public AppUserConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }

        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("TBL_USUARIOS", Tipos.Esquema());

            builder
                .HasOne(user => user.Profile)
                .WithOne()
                .HasForeignKey<Perfil>(perfil => perfil.Id);
        }
    }
}
