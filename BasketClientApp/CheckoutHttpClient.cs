using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace CheckoutClientApp
{
    public class CheckoutHttpClient
    {
        private static IConfigurationRoot _configuration;

        public CheckoutHttpClient(IConfigurationRoot configuration)
        {
            _configuration = configuration;
        }


        public async Task<decimal?> GetTotalPrice(IList<string> skus)
        {
            using (HttpClient client = new HttpClient())
            {
                var requestUrl = GenerateRequestUrl(skus);
                var response = client.GetAsync(requestUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return decimal.Parse(responseBody);
                }
                else
                {
                    return null; //TODO MVC - handle and display errors.
                }

            }
        }

        private static string GenerateRequestUrl(IList<string> skus)
        {
            var domain = _configuration.GetConnectionString("CheckoutServer");
            var method = "api/basket/totalPrice";
            var queryParams = GenerateQueryString(skus);

            return Path.Combine(Path.Combine(domain, method), queryParams);
        }

        private static string GenerateQueryString(IList<string> skus)
        {
            string queryString = "";
            var first = true;

            //TODO MVC - add validation of the inputs for illegal characters, or html encode the input

            foreach (var sku in skus)
            {
                if (first)
                {
                    queryString += "?sku=" + sku;
                    first = false;
                }
                else
                {
                    queryString += "&sku=" + sku;
                }
            }

            return queryString;
        }        
    }
}
