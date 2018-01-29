﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using AdProject.Infraestrutura.Identity;

namespace AdProject.Infraestrutura.Data.Contexts.Configurations
{
    public class AppUserClaimConfig : IEntityTypeConfiguration<AppUserClaim>
    {
        public void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            builder.ToTable("TBL_USER_CLAIMS", AdProjectContext.SCHEME_NAME);
        }
    }
}
