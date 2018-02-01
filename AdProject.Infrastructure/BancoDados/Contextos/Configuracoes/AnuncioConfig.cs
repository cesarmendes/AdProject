using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class AnuncioConfig : IEntityTypeConfiguration<Anuncio>
    {
        public void Configure(EntityTypeBuilder<Anuncio> builder)
        {
            builder
                .ToTable("TBL_ANUNCIOS", AdProjectContext.SCHEME_NAME)
                .HasKey(anuncio => anuncio.Id);

            builder
                .Property(anuncio => anuncio.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_BIGINT)
                .ValueGeneratedOnAdd();

            builder
                .Property(anuncio => anuncio.Data)
                .HasColumnName("DATA")
                .HasColumnType(AdProjectContext.TYPE_DATETIME)
                .IsRequired();

            builder
                .Property(anuncio => anuncio.Descricao)
                .HasColumnName("DESCRICAO")
                  .HasColumnType("VARCHAR(1000)")
                //.HasColumnType(AdProjectContext.TYPE_STRING)
                //.HasMaxLength(1000)
                .IsRequired();

            builder.Property(anuncio => anuncio.Titulo)
                .HasColumnName("TITULO")
                .HasColumnType("VARCHAR(200)")
                //.HasColumnType(AdProjectContext.TYPE_STRING)
                //.HasMaxLength(200)
                .IsRequired();

            builder
                .Property(anuncio => anuncio.ValorAnterior)
                .HasColumnName("VALOR_ANTERIOR")
                .HasColumnType(AdProjectContext.TYPE_DECIMAL);
                
            builder
                .Property(anuncio => anuncio.Valor)
                .HasColumnName("VALOR")
                .HasColumnType(AdProjectContext.TYPE_DECIMAL)
                .IsRequired();
        }
    }
}
