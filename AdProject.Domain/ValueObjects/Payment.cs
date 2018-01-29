using System;
using System.Collections.Generic;
using System.Text;

namespace AdProject.Dominio.ValueObjects
{
    public class Payment
    {
        public decimal Amount { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}
