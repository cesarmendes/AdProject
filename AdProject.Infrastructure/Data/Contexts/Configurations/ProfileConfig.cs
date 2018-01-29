using AdProject.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdProject.Infraestrutura.Data.Contexts.Configurations
{
    public class ProfileConfig : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder
                .ToTable("TBL_PROFILES", AdProjectContext.SCHEME_NAME)
                .HasKey(profile => profile.Id);

            builder
                .Property(profile => profile.Id)
                .HasColumnName("ID")
                .HasColumnType(AdProjectContext.TYPE_BIGINT)
                .ValueGeneratedNever();
        }

        
    }
}
