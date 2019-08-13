using Checkout.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Core.Interfaces
{
    public interface IOfferRepository
    {
       IEnumerable<Offer> GetOffers(IEnumerable<string> skus);
    }
}
