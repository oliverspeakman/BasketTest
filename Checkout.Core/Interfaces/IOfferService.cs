using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Entities;

namespace Checkout.Core.Interfaces
{
    public interface IOfferService
    {        
        //TODO MVP - this structure only allows 1 product to belong to 1 offer, insert a list in the middle to allow multiple offers on one sku
        IDictionary<string,Offer> GetOffers(IEnumerable<string> skus);

        decimal CalculateOfferPrice(BasketItem basketItem, Offer matchingOffer);
    }
}
