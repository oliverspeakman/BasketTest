using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Checkout.Core.Entities;
using Checkout.Core.Interfaces;

namespace Checkout.Core.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private static IDictionary<string, Offer> _offers; //TODO this structure only allows 1 offer per product, add a list to the dictionary for 1 to many mapping

        static OfferRepository()
        {
            _offers = LoadHardCodedOffers(); //TODO replace with a database
        }

        public IEnumerable<Offer> GetOffers(IEnumerable<string> skus)
        {
            foreach (var sku in skus)
            {
                if (_offers.ContainsKey(sku))
                {
                    yield return _offers[sku];
                }
            }
        }

        private static IDictionary<string, Offer> LoadHardCodedOffers() 
        {
            var offers = new  Dictionary<string,Offer>();

            var offer = new MultiBuyOffer( "A99",3,1.3M);
            offers.Add(offer.Sku,offer);

            offer = new MultiBuyOffer("B15", 2, 0.45M);
            offers.Add(offer.Sku, offer);

            return offers;

        }
    }
}
