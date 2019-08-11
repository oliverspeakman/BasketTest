using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using Checkout.Core;
using Checkout.Core.Entities;
using Checkout.Core.Interfaces;
using Checkout.Core.Repositories;
using Checkout.Core.Services;

namespace BasketClientApp
{
    class Program
    {
        private static IBasketService _basketService { get; set; }

        private static IProductService _productService { get; set; }

        private static Basket _basket { get; set; }

        static Program()
        {
            _basket = new Basket();
            _basketService = new BasketService(new OfferService(new OfferRepository())); //TODO add dependency injection
            _productService = new ProductService(new ProductRepository());
        }

        static void Main(string[] args)
        {                     
            ReadProductSkus();            
        }

        private static void ReadProductSkus()
        {            
            while(true)
            {
                string input = Console.ReadLine();

                 var product = _productService.Get(input);

                 if (product == null)
                 {
                     Console.WriteLine("No matching product found for Sku - " + input);
                     continue;
                 }
                 else
                 {
                     _basket.Add(product, 1);            
                     DisplayBasket();
                 }                
            }
        }

        private static void DisplayBasket()
        {
            Console.WriteLine( $"BASKET - ITEMS = { _basket.BasketItems.Values.Sum(x => x.Quantity)}");
            foreach (var basketItem in _basket.BasketItems)
            {
                Console.WriteLine($"{basketItem.Value.Product.Description} X {basketItem.Value.Quantity}");
            }

            Console.WriteLine($"TOTAL PRICE = { _basket.TotalPrice.ToString("£##.00") }");
        }

    }
}
