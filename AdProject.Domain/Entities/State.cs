using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Domain.Entities
{
    public class State : Entity<int>
    {
        public int IdCountry { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
