using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Domain.Entities
{
    public class Country : Entity<int>
    {
        public string Name { get; set; }

        public virtual ICollection<State> States { get; set; }
    }
}
