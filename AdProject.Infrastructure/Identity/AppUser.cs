using AdProject.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Infrastructure.Identity
{
    public class AppUser : IdentityUser<long>
    {
        public virtual Profile Profile { get; set; }
    }
}
