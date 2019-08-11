using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Entities;
using Checkout.Core.Interfaces;

namespace Checkout.Core.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        public IEnumerable<BaseOffer> GetOffers(IEnumerable<string> skus)
        {
            throw new NotImplementedException();
        }
    }
}
