using AdProject.Infraestrutura.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infraestrutura.Data.Contexts.Configurations
{
    public class AppUserTokenConfig : IEntityTypeConfiguration<AppUserToken>
    {
        public void Configure(EntityTypeBuilder<AppUserToken> builder)
        {
            builder.ToTable("TBL_USER_TOKENS", AdProjectContext.SCHEME_NAME);
        }
    }
}
