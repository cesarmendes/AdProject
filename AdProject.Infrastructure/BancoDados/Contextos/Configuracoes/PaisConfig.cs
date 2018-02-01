using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class PaisConfig : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> builder)
        {
            builder
                .ToTable("TBL_PAISES", AdProjectContext.SCHEME_NAME)
                .HasKey(pais => pais.Id);

            builder
                .Property(pais => pais.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_STRING)
                .ValueGeneratedNever();

            builder
                .Property(pais => pais.Codigo)
                .HasColumnName("CODIGO")
                .HasColumnType("VARCHAR(3)")
                //.HasColumnType(AdProjectContext.TYPE_STRING)
                //.HasMaxLength(3)
                .IsRequired();

            builder
                .Property(pais => pais.Nome)
                .HasColumnName("NOME")
                .HasColumnType("VARCHAR(300)")
                //.HasColumnType(AdProjectContext.TYPE_STRING)
                //.HasMaxLength(100)
                .IsRequired();
        }
    }
}
