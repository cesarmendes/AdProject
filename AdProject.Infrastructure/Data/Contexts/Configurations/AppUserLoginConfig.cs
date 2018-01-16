using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Infrastructure.Identity;

namespace AdProject.Infrastructure.Data.Contexts.Configurations
{
    public class AppUserLoginConfig : IEntityTypeConfiguration<AppUserLogin>
    {
        public void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {
            builder.ToTable("TBL_USER_LOGINS", AdProjectContext.SCHEME_NAME);
        }
    }
}
