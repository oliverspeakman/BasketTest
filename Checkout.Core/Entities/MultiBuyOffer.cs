using System;
using System.Collections.Generic;
using System.Text;

namespace Checkout.Core.Entities
{
    public class MultiBuyOffer : BaseOffer
    {        
        public int QuantityRequired { get; set; }
        public decimal Price { get; set; }
    }
}
