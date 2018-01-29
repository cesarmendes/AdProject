﻿using AdProject.Infraestrutura.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AdProject.Infraestrutura.Data.Contexts.Configurations
{
    public class AppRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.ToTable("TBL_ROLES", AdProjectContext.SCHEME_NAME);
        }
    }
}
