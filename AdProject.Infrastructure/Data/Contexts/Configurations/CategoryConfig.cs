using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdProject.Infraestrutura.Data.Contexts.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder
               .ToTable("TBL_CATEGORIES", AdProjectContext.SCHEME_NAME)
               .HasKey(category => category.Id);

            builder
                .Property(category => category.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_BIGINT)
                .ValueGeneratedOnAdd();

            builder
                .Property(category => category.Nome)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR(300)")
                //.HasColumnType(AdProjectContext.TYPE_STRING)
                //.HasMaxLength(300)
                .IsRequired();
        }
    }
}
