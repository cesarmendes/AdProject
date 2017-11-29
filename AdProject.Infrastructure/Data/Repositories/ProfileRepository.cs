using AdProject.Domain.Entities;
using AdProject.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infrastructure.Data.Repositories
{
    public class ProfileRepository : Repository<long, Profile>, IProfileRepository
    {
        public ProfileRepository(DbContext context)
            : base(context)
        {
        }
    }
}
