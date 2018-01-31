using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Infraestrutura.Identity;

namespace AdProject.Infraestrutura.BancoDados.Contextos.Configuracoes
{
    public class AppUserLoginConfig : IEntityTypeConfiguration<AppUserLogin>
    {
        public void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {
            builder.ToTable("TBL_USUARIO_LOGINS", AdProjectContext.SCHEME_NAME);
        }
    }
}
