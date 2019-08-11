using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Core.Entities
{
    public class BasketItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; set; }

        public BasketItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
    }
}
