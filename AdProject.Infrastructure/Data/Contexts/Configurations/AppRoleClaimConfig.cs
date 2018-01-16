using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Infrastructure.Identity;

namespace AdProject.Infrastructure.Data.Contexts.Configurations
{
    public class AppRoleClaimConfig : IEntityTypeConfiguration<AppRoleClaim>
    {
        public void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            builder.ToTable("TBL_ROLE_CLAIMS", AdProjectContext.SCHEME_NAME);
        }
    }
}
