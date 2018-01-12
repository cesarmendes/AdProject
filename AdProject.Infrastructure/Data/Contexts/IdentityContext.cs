using AdProject.Domain.Entities;
using AdProject.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infrastructure.Data.Contexts
{
    public class IdentityContext : IdentityDbContext<UserIdentity, RoleIdentity, long>
    {
        public IdentityContext()
            : base()
        {

        }
        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {

        }

        public DbSet<Profile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Profile>()
                .ToTable("TBL_PROFILES")
                .HasKey(profile => profile.Id);

            builder.Entity<Profile>()
                .Property(profile => profile.Id)
                .HasColumnName("ID")
                .HasColumnType("BIGINT")
                .ValueGeneratedNever();

            builder
                .Entity<UserIdentity>()
                .HasOne(user=>user.Profile)
                .WithOne()
                .HasForeignKey<Profile>(profile=> profile.Id);
           

            base.OnModelCreating(builder);
        }
    }
}
