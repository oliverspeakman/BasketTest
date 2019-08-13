using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Entities;
using Checkout.Core.Interfaces;
using Checkout.Core.Services;

namespace Checkout.Core
{
    public class BasketService : IBasketService
    {
        private IOfferService _offerService { get;}
        private IProductService _productService { get;}

        public BasketService(IOfferService offerService, IProductService productService)
        {
            _offerService = offerService;
            _productService = productService;
        }

        public decimal CalculateTotalPrice(IEnumerable<string> skus)
        {
            decimal totalPrice = 0;

            var basket = this.CreateBasket(skus);
            var offers = _offerService.GetOffers(basket.Skus);

            foreach (var sku in basket.Skus)
            {
                BasketItem basketItem = basket.BasketItems[sku];

                var offer = offers[sku];
                
                decimal basketItemPrice;

                if (offer != null)
                {
                    basketItemPrice = _offerService.CalculateOfferPrice(basketItem, offer);
                }
                else
                {
                    basketItemPrice = basketItem.Quantity * basketItem.Product.UnitPrice;
                }

                totalPrice += basketItemPrice;
            }

            return totalPrice;
        }

        private Basket CreateBasket(IEnumerable<string> skus)
        {
            var basket = new Basket();

            foreach (var sku in skus)
            {
                var product = _productService.Get(sku);

                if (product != null)
                {
                    basket.Add(product,1);
                }
                else
                {
                    //TODO MVP - add an invalid products section to the basket
                }
            }

            return basket;
        }
    }
}
