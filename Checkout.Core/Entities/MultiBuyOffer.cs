using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Enums;

namespace Checkout.Core.Entities
{
    public class MultiBuyOffer : Offer
    {        
        public int QuantityRequired { get; private set; }
        public decimal Price { get; private set; }
        
        public MultiBuyOffer(string sku,int quantityRequired,decimal price) : base( sku,OfferType.MultiBuy)
        {
            QuantityRequired = quantityRequired;
            Price = price;
        }
    }
}
