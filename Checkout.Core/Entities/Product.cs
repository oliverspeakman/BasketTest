using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Core.Entities
{
    public class Product
    {
        public string Sku { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
