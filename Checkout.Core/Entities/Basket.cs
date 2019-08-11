using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Interfaces;
using Checkout.Core.Repositories;
using Checkout.Core.Services;

namespace Checkout.Core.Entities
{
    public class Basket
    {
        private static IBasketService _basketService { get; set; }

        public IDictionary<string,BasketItem> BasketItems { get; private set; }

        public decimal TotalPrice { get; private set; }

        static Basket()
        {
            _basketService = new BasketService(new OfferService(new OfferRepository())); //TODO added static construcor injection
        }

        public Basket()
        {
            BasketItems = new Dictionary<string, BasketItem>();
        }

        public void Add(Product product,int quantity)
        {
            Add(new BasketItem(product,quantity));
        }
        
        private void Add(BasketItem basketItem)
        {
            if (!BasketItems.ContainsKey(basketItem.Product.Sku))
            {
                BasketItems.Add(basketItem.Product.Sku, basketItem);
            }
            else
            {
                var existingBasketItem = BasketItems[basketItem.Product.Sku];

                existingBasketItem.Quantity += basketItem.Quantity;
            }

            TotalPrice  = _basketService.CalculateTotalPrice(this);
        }
    }
}
