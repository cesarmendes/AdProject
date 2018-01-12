using AdProject.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Domain.Entities
{
    public class Profile : Entity<long>
    {
        public string Name { get; set; }
    }
}
