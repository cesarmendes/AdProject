using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Infraestrutura.BancoDados.Contextos.Tipos;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        TiposBaseDados Tipos {get;set;}

        public CategoriaConfig(TiposBaseDados tipos)
        {
            this.Tipos = tipos;
        }
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder
               .ToTable("TBL_CATEGORIAS", Tipos.Esquema())
               .HasKey(categoria => categoria.Id);

            builder
                .Property(categoria => categoria.Id)
                .HasColumnName("ID")
                .HasColumnType(Tipos.Int())
                .ValueGeneratedOnAdd();

            builder
                .Property(categoria => categoria.Nome)
                .HasColumnName("NOME")
                .HasColumnType(Tipos.String())
                .HasMaxLength(300)
                .IsRequired();

            builder
                .HasMany(categoria => categoria.SubCategorias)
                .WithOne(subcategoria => subcategoria.Categoria)
                .HasForeignKey(subcategoria => subcategoria.IdCategoria)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
