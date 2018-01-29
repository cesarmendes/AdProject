using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Dominio.Entidades;
using AdProject.Infraestrutura.Identity;

namespace AdProject.Infraestrutura.Data.Contexts.Configurations
{
    public class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.ToTable("TBL_USERS", AdProjectContext.SCHEME_NAME);

            builder
                .HasOne(user => user.Profile)
                .WithOne()
                .HasForeignKey<Perfil>(profile => profile.Id);
        }
    }
}
