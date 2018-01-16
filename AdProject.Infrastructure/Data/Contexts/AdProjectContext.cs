using AdProject.Domain.Entities;
using AdProject.Infrastructure.Data.Contexts.Configurations;
using AdProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infrastructure.Data.Contexts
{
    public class AdProjectContext : IdentityDbContext<AppUser, AppRole, long, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public static readonly string SCHEME_NAME = "dbo";
        public static readonly string TYPE_INT = "INT";
        public static readonly string TYPE_BIGINT = "BIGINT";
        public static readonly string TYPE_BOOL = "BIT";
        public static readonly string TYPE_STRING = "VARCHAR";
        public static readonly string TYPE_TEXT = "TEXT";


        public AdProjectContext()
            : base()
        {

        }
        public AdProjectContext(DbContextOptions<AdProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);


            builder.ApplyConfiguration<Profile>(new AdProfileConfig());


            //Asp.Net Identity configuration
            builder.ApplyConfiguration<AppRoleClaim>(new AppRoleClaimConfig());
            builder.ApplyConfiguration<AppUserClaim>(new AppUserClaimConfig());
            builder.ApplyConfiguration<AppUserLogin>(new AppUserLoginConfig());
            builder.ApplyConfiguration<AppUserRole>(new AppUserRoleConfig());
            builder.ApplyConfiguration<AppUserToken>(new AppUserTokenConfig());
            builder.ApplyConfiguration<AppRole>(new AppRoleConfig());
            builder.ApplyConfiguration<AppUser>(new AppUserConfig());
        }
    }
}
