using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Infraestrutura.BancoDados.Contextos.Tipos;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class SubcategoriaConfig : IEntityTypeConfiguration<Subcategoria>
    {
        TiposBaseDados Tipos { get; set; }

        public SubcategoriaConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }
        public void Configure(EntityTypeBuilder<Subcategoria> builder)
        {
            builder
                .ToTable("TBL_SUBCATEGORIAS", Tipos.Esquema())
                .HasKey(subcategoria => subcategoria.Id);

            builder
                .Property(subcategoria => subcategoria.Id)
                .HasColumnName("ID")
                .HasColumnType(Tipos.Int())
                .ValueGeneratedOnAdd();

            builder
                .Property(subcategoria => subcategoria.Nome)
                .HasColumnName("NAME")
                .HasColumnType(Tipos.String())
                .HasMaxLength(300)
                .IsRequired();

            builder
                .HasOne(subcategoria => subcategoria.Categoria)
                .WithMany(categoria => categoria.SubCategorias)
                .HasForeignKey(subcategoria => subcategoria.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
