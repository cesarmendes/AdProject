using AdProject.Dominio.Entidades;
using AdProject.Infraestrutura.BancoDados.Contextos.Tipos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class EstadoConfig : IEntityTypeConfiguration<Estado>
    {
        TiposBaseDados Tipos { get; set; }

        public EstadoConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder
                .ToTable("TBL_ESTADOS", Tipos.Esquema())
                .HasKey(estado => estado.Id);

            builder
                .Property(estado => estado.Id)
                .HasColumnName("ID")
                .HasColumnType(Tipos.Int())
                .ValueGeneratedNever();

            builder
                .Property(estado => estado.IdPais)
                .HasColumnName("ID_PAIS")
                .HasColumnType(Tipos.Int());

            builder
                .Property(estado => estado.Codigo)
                .HasColumnName("CODIGO")
                .HasColumnType(Tipos.String())
                .HasMaxLength(2)
                .IsRequired();

            builder
                .Property(estado => estado.Nome)
                .HasColumnName("NOME")
                .HasColumnType(Tipos.String())
                .HasMaxLength(300)
                .IsRequired();

            builder
                .HasMany(estado => estado.Cidades)
                .WithOne(cidade => cidade.Estado)
                .HasForeignKey(cidade => cidade.IdEstado)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
