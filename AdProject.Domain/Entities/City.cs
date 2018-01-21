using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Domain.Entities
{
    public class City : Entity<int>
    {
        public int IdState { get; set; }
        public string Name { get; set; }
        public virtual State State { get; set; }
    }
}
