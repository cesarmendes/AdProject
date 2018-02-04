using AdProject.Dominio.Entidades;
using AdProject.Infraestrutura.BancoDados.Contextos.Tipos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class PaisConfig : IEntityTypeConfiguration<Pais>
    {
        TiposBaseDados Tipos { get; set; }

        public PaisConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder
                .ToTable("TBL_PAISES", Tipos.Esquema())
                .HasKey(pais => pais.Id);

            builder
                .Property(pais => pais.Id)
                .HasColumnName("ID")
                .HasColumnType(Tipos.Int())
                .ValueGeneratedNever();

            builder
                .Property(pais => pais.Codigo)
                .HasColumnName("CODIGO")
                .HasColumnType(Tipos.String())
                .HasMaxLength(3)
                .IsRequired();

            builder
                .Property(pais => pais.Nome)
                .HasColumnName("NOME")
                .HasColumnType(Tipos.String())
                .HasMaxLength(100)
                .IsRequired();

            builder
                .HasMany(pais => pais.Estados)
                .WithOne(estado => estado.Pais)
                .HasForeignKey(estado => estado.IdPais)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
