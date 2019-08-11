using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Entities;
using Checkout.Core.Interfaces;

namespace Checkout.Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private static IDictionary<string,Product> _products;


        static ProductRepository()
        {
            _products = GetHardcodedProducts(); //TODO Replace with a database
        }

        public Product Get(string sku)
        {            
            _products.TryGetValue(sku, out var product);
            
            return product;
        }
       

        private static IDictionary<string,Product> GetHardcodedProducts()
        {
            IDictionary<string,Product> products = new Dictionary<string,Product>();

            var product = new Product()
            {
                Sku = "A99",
                Description = "Apple",
                UnitPrice = 0.5M

            };

            products.Add(product.Sku,product);


            product = new Product()
            {
                Sku = "B15",
                Description = "Biscuits",
                UnitPrice = 0.3M
            };
            products.Add(product.Sku,product);

            product = new Product()
            {
                Sku = "C40",
                Description = "Coffee",
                UnitPrice = 1.8M
            };
            products.Add(product.Sku,product);

            product = new Product()
            {
                Sku = "T23",
                Description = "Tissues",
                UnitPrice = 0.99M
            };
            products.Add(product.Sku,product);

            return products;
        }
    }
}
