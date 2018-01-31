using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder
               .ToTable("TBL_CATEGORIAS", AdProjectContext.SCHEME_NAME)
               .HasKey(categoria => categoria.Id);

            builder
                .Property(categoria => categoria.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_BIGINT)
                .ValueGeneratedOnAdd();

            builder
                .Property(categoria => categoria.Nome)
                .HasColumnName("NOME")
                .HasColumnType("VARCHAR(300)")
                //.HasColumnType(AdProjectContext.TYPE_STRING)
                //.HasMaxLength(300)
                .IsRequired();
        }
    }
}
