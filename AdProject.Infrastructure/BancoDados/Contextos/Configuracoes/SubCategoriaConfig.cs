using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class SubcategoriaConfig : IEntityTypeConfiguration<Subcategoria>
    {
        public void Configure(EntityTypeBuilder<Subcategoria> builder)
        {
            builder
                .ToTable("TBL_SUBCATEGORIAS", AdProjectContext.SCHEME_NAME)
                .HasKey(subcategoria => subcategoria.Id);

            builder
                .Property(subcategoria => subcategoria.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_BIGINT)
                .ValueGeneratedOnAdd();

            builder
                .Property(subcategoria => subcategoria.Nome)
                .HasColumnName("NAME")
                .HasColumnName("VARCHAR(300)")
                //.HasColumnType(AdProjectContext.TYPE_STRING)
                //.HasMaxLength(300)
                .IsRequired();

            builder
                .HasOne(subcategoria => subcategoria.Categoria)
                .WithMany(categoria => categoria.SubCategorias)
                .HasForeignKey(subcategoria => subcategoria.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
