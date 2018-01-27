using AdProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infrastructure.Data.Contexts.Configurations
{
    public class AnnouncementConfig : IEntityTypeConfiguration<Advertisement>
    {
        public void Configure(EntityTypeBuilder<Advertisement> builder)
        {
            builder
                .ToTable("TBL_ADVERTS", AdProjectContext.SCHEME_NAME)
                .HasKey(announcement => announcement.Id);

            builder
                .Property(announcement => announcement.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_BIGINT)
                .ValueGeneratedOnAdd();

            builder
                .Property(announcement => announcement.Price)
                .HasColumnName("PRICE")
                .HasColumnType(AdProjectContext.TYPE_DECIMAL)
                .IsRequired();
        }
    }
}
