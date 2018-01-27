using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Domain.Entities
{
    public class Advertisement : Entity<long>
    {
        public string Title { get; set; }
        public decimal Price { get; set; }
        public Nullable<decimal> PricePrevious { get; set; }
    }
}
