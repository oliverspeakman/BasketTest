using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Checkout.Core;
using Checkout.Core.Entities;
using Checkout.Core.Interfaces;
using Checkout.Core.Repositories;
using Checkout.Core.Services;
using CheckoutClientApp;
using Microsoft.Extensions.Configuration;

namespace BasketClientApp
{
    class Program
    {
        private static IConfigurationRoot _configuration;        
        
        static void Main(string[] args)
        {
            LoadConfiguration();            
            DisplayInstructions();
            ReadProductSkus();            
        }

        private static void LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            _configuration = builder.Build();
        }
        
        private static void DisplayInstructions()
        {
            Console.WriteLine("Enter Individual Product Skus followed by <RETURN>.");
            Console.WriteLine("Press <RETURN> without a product Sku to Checkout.");
            Console.WriteLine("Your Basket will be cleared after Checkout.");
        }

        private static void ReadProductSkus()
        {     
            IList<string> skus = new List<string>();            

            while(true)
            {
                string input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input))
                {
                    skus.Add(input);
                }
                else
                {
                    ProcessBasket(skus);
                    ClearBasket(ref skus);
                }  
            }
        }

        private static void ProcessBasket(IList<string> skus)
        {
            CheckoutHttpClient client = new CheckoutHttpClient(_configuration);
            var totalPrice = client.GetTotalPrice(skus);

            if (totalPrice.Result != null)
            {
                Console.WriteLine($"Total Price = {totalPrice.Result.Value.ToString("£0.00")}");
            }
        }

        private static void ClearBasket(ref IList<string> skus)
        {
            skus = new List<string>();
        }        
    }
}
