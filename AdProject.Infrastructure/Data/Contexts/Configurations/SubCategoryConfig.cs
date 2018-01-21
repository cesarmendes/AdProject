using AdProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdProject.Infrastructure.Data.Contexts.Configurations
{
    public class SubCategoryConfig : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder
                .ToTable("TBL_SUBCATEGORIES", AdProjectContext.SCHEME_NAME)
                .HasKey(subCategory => subCategory.Id);

            builder
                .Property(subCategory => subCategory.Id)
                .HasColumnName("ID")
                .HasColumnType("BIGINT")
                .ValueGeneratedOnAdd();

            builder
                .Property(subCategory => subCategory.Name)
                .HasColumnName("NAME")
                .HasColumnType("VARCHAR")
                .HasMaxLength(300)
                .IsRequired();

            builder
                .HasOne(subCategory => subCategory.Category)
                .WithMany(category => category.SubCategories)
                .HasForeignKey(subCategory => subCategory.IdCategory)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
