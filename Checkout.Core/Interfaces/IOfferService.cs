using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Entities;

namespace Checkout.Core.Interfaces
{
    public interface IOfferService
    {
        void CreateOffer(BaseOffer offer);

        //TODO this structure only allows 1 product to belong to 1 offer, insert a list in the middle to allow multiple offers on one sku
        IDictionary<string,BaseOffer> GetOffers(Basket basket);

        decimal CalculateOfferPrice(BasketItem basketItem, BaseOffer matchingOffer);
    }
}
