using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Entities;

namespace Checkout.Core.Interfaces
{
    public interface IBasketService
    {        
        decimal CalculateTotalPrice(IEnumerable<string> skus);
    }
}
