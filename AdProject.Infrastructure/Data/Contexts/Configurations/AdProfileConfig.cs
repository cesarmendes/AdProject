using AdProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdProject.Infrastructure.Data.Contexts.Configurations
{
    internal class AdProfileConfig : IEntityTypeConfiguration<Profile>
    {
        public void Configure(EntityTypeBuilder<Profile> builder)
        {
            builder
                .HasKey(profile => profile.Id);

            builder
                .ToTable(ProfileTable.TABLE_NAME, ProfileTable.SCHEME_NAME);

            builder
                .Property(profile => profile.Id)
                .HasColumnName(ProfileTable.FIELD_ID)
                .HasColumnType(ProfileTable.TYPE_BIGINT)
                .ValueGeneratedOnAdd();

        }
    }
}
