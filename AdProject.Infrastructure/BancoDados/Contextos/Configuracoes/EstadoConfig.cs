using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class EstadoConfig : IEntityTypeConfiguration<Estado>
    {
        public void Configure(EntityTypeBuilder<Estado> builder)
        {
            builder
                .ToTable("TBL_ESTADOS", AdProjectContext.SCHEME_NAME)
                .HasKey(estado => estado.Id);

            builder
                .Property(estado => estado.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_INT)
                .ValueGeneratedNever();

            builder
                .Property(estado => estado.IdPais)
                .HasColumnName("ID_PAIS")
                .HasColumnType(AdProjectContext.TYPE_INT);

            builder
                .Property(estado => estado.Codigo)
                .HasColumnName("CODIGO")
                .HasColumnType("VARCHAR(2)")
                //.HasColumnType(AdProjectContext.TYPE_STRING)
                //.HasMaxLength(2)
                .IsRequired();

            builder
                .Property(estado => estado.Nome)
                .HasColumnName("NOME")
                .HasColumnType("VARCHAR(300)")
                //.HasColumnType(AdProjectContext.TYPE_STRING)
                //.HasMaxLength(300)
                .IsRequired();
        }
    }
}
