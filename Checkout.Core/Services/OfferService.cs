using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Checkout.Core.Entities;
using Checkout.Core.Enums;
using Checkout.Core.Interfaces;

namespace Checkout.Core.Services
{
    public class OfferService : IOfferService
    {
        private IOfferRepository _offerRepository { get; set; }

        public OfferService(IOfferRepository offerRepository)
        {
            _offerRepository = offerRepository;
        }

        public void CreateOffer(BaseOffer offer)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, BaseOffer> GetOffers(Basket basket)
        {
            var skus = basket.BasketItems.Keys;

            var offers = _offerRepository.GetOffers(skus);

            var matchingOffers = offers.Where(x => skus.Contains(x.Sku)).ToDictionary(x => x.Sku);

            return matchingOffers;
        }

        public decimal CalculateOfferPrice(BasketItem basketItem, BaseOffer matchingOffer)
        {

            switch (matchingOffer.OfferType)
            {
                case OfferType.MultiBuy:
                    return CalculateMultiBuyOfferPrice((MultiBuyOffer) matchingOffer, basketItem);
                default:
                    throw new ArgumentException("Unknown offer type - " + matchingOffer.OfferType);
            }

        }

        //TODO refactor into base service or the entity
        private decimal CalculateMultiBuyOfferPrice(MultiBuyOffer offer,BasketItem basketItem)
        {
            var totalQuantity = basketItem.Quantity;
            var quantityRequired = offer.QuantityRequired;

            var offersMatched = totalQuantity % quantityRequired;

            var offerPrice = offersMatched * offer.Price;
            var unmatchingQuantity = quantityRequired - offersMatched;

            var nonOfferPrice = unmatchingQuantity * basketItem.Product.UnitPrice;

            return offerPrice + nonOfferPrice;
        }       
    }
}
