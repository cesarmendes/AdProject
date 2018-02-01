using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class CidadeConfig : IEntityTypeConfiguration<Cidade>
    {
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder
                .ToTable("TBL_CIDADES", AdProjectContext.SCHEME_NAME)
                .HasKey(cidade => cidade.Id);

            builder
                .Property(cidade => cidade.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_INT)
                .ValueGeneratedNever();

            builder
                .Property(cidade => cidade.IdEstado)
                .HasColumnName("ID_ESTADO")
                .HasColumnType(AdProjectContext.TYPE_INT)
                .IsRequired();

            builder
                .Property(cidade => cidade.Nome)
                .HasColumnName("NOME")
                .HasColumnType("VARCHAR(300)")
                //.HasColumnType(AdProjectContext.TYPE_STRING)
                //.HasMaxLength(300)
                .IsRequired();
                
        }
    }
}
