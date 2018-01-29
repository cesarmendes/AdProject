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
                .ToTable("TBL_ADVERTS", AdProjectContext.SCHEME_NAME)
                .HasKey(announcement => announcement.Id);

            builder
                .Property(announcement => announcement.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_BIGINT)
                .ValueGeneratedOnAdd();

            builder
                .Property(announcement => announcement.Preco)
                .HasColumnName("PRICE")
                .HasColumnType(AdProjectContext.TYPE_DECIMAL)
                .IsRequired();
        }
    }
}
