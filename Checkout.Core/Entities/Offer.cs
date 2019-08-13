using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Enums;

namespace Checkout.Core.Entities
{
    public abstract class Offer
    {
        public OfferType OfferType { get; set;}
        public string Sku { get; private set; }

        protected Offer(string sku,OfferType type)
        {
            Sku = sku;
            OfferType = type;
        }
    }
}
