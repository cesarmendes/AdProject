using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Domain.Entities
{
    public class SubCategory : Entity<long>
    {
        public long IdCategory { get; set; }
        public string Name { get; set; }
        public virtual Category Category { get; set; }
    }
}
