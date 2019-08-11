using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Entities;

namespace Checkout.Core.Tests.Helpers
{
    class DataHelper
    {
        public static Product GetAppleProduct()
        {
            var newProduct = new Product()
            {
                Sku = "A99",
                Description = "Apple",
                UnitPrice = 0.5M
            };

            return newProduct;
        }
    }
}
