using AdProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdProject.Infrastructure.Data.Contexts.Configurations
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder
               .ToTable("TBL_CATEGORIES", AdProjectContext.SCHEME_NAME)
               .HasKey(category => category.Id);

            builder
                .Property(category => category.Id)
                .HasColumnName("ID")
                .HasColumnType("BIGINT")
                .ValueGeneratedOnAdd();

            builder
                .Property(category => category.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR")
                .HasMaxLength(300)
                .IsRequired();
        }
    }
}
