using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Infraestrutura.Identity;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class AppUserRoleConfig : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.ToTable("TBL_USER_ROLES", AdProjectContext.SCHEME_NAME);
        }
    }
}
