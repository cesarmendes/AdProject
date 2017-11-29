using AdProject.Domain.Entities;
using AdProject.Infrastructure.Data.Contexts.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infrastructure.Data.Contexts
{
    public class AdContext : DbContext
    {
        public AdContext()
            : base()
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Profile>(new AdProfileConfig());



            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
