using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class SubCategoriaConfig : IEntityTypeConfiguration<SubCategoria>
    {
        public void Configure(EntityTypeBuilder<SubCategoria> builder)
        {
            builder
                .ToTable("TBL_SUBCATEGORIES", AdProjectContext.SCHEME_NAME)
                .HasKey(subCategory => subCategory.Id);

            builder
                .Property(subCategory => subCategory.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_BIGINT)
                .ValueGeneratedOnAdd();

            builder
                .Property(subCategory => subCategory.Nome)
                .HasColumnName("NAME")
                .HasColumnName("VARCHAR(300)")
                //.HasColumnType(AdProjectContext.TYPE_STRING)
                //.HasMaxLength(300)
                .IsRequired();

            builder
                .HasOne(subCategory => subCategory.Categoria)
                .WithMany(category => category.SubCategorias)
                .HasForeignKey(subCategory => subCategory.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
