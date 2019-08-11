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
        private IOfferService _offerService { get; set;  }

        public BasketService(IOfferService offerService)
        {
            _offerService = offerService;
        }

        public void Add(Basket basket, Product product)
        {
            throw new NotImplementedException();
        }

        public decimal CalculateTotalPrice(Basket basket)
        {
            decimal totalPrice = 0;
            var offers = _offerService.GetOffers(basket);

            foreach (var basketItem in basket.BasketItems.Values)
            {
                var offer = offers[basketItem.Product.Sku];
                
                decimal basketItemPrice;

                if (offer != null)
                {
                    basketItemPrice = _offerService.CalculateOfferPrice(basketItem,offer);
                }
                else
                {
                    basketItemPrice = basketItem.Quantity * basketItem.Product.UnitPrice;
                }

                totalPrice += basketItemPrice;
            }

            return totalPrice;
        }
    }
}
