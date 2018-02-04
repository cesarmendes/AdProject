using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Infraestrutura.BancoDados.Contextos.Tipos;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class PerfilConfig : IEntityTypeConfiguration<Perfil>
    {
        TiposBaseDados Tipos { get; set; }

        public PerfilConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder
                .ToTable("TBL_PEFIS", Tipos.Esquema())
                .HasKey(perfil => perfil.Id);

            builder
                .Property(perfil => perfil.Id)
                .HasColumnName("ID")
                .HasColumnType(Tipos.BigInt())
                .ValueGeneratedNever();
        }

        
    }
}
