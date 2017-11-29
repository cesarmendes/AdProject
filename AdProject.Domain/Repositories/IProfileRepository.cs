using AdProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Domain.Repositories
{
    public interface IProfileRepository : IRepository<long, Profile>
    {
    }
}
