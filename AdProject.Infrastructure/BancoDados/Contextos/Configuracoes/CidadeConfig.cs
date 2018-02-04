using AdProject.Dominio.Entidades;
using AdProject.Infraestrutura.BancoDados.Contextos.Tipos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class CidadeConfig : IEntityTypeConfiguration<Cidade>
    {
        TiposBaseDados Tipos { get; set; }

        public CidadeConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }
        public void Configure(EntityTypeBuilder<Cidade> builder)
        {
            builder
                .ToTable("TBL_CIDADES", Tipos.Esquema())
                .HasKey(cidade => cidade.Id);

            builder
                .Property(cidade => cidade.Id)
                .HasColumnName("ID")
                .HasColumnType(Tipos.Int())
                .ValueGeneratedNever();

            builder
                .Property(cidade => cidade.IdEstado)
                .HasColumnName("ID_ESTADO")
                .HasColumnType(Tipos.Int())
                .IsRequired();

            builder
                .Property(cidade => cidade.Nome)
                .HasColumnName("NOME")
                .HasColumnType(Tipos.String())
                .HasMaxLength(300)
                .IsRequired();
                
        }
    }
}
