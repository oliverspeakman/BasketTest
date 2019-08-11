using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Enums;

namespace Checkout.Core.Entities
{
    public abstract class BaseOffer
    {
        public OfferType OfferType { get; set;}
        public string Sku { get; set; }
    }
}
