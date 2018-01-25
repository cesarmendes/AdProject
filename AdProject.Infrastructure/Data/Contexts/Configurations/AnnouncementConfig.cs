using AdProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infrastructure.Data.Contexts.Configurations
{
    public class AnnouncementConfig : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder
                .ToTable("TBL_ANNOUNCEMENTS", AdProjectContext.SCHEME_NAME)
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
