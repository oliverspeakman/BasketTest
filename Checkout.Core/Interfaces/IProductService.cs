using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Entities;

namespace Checkout.Core.Interfaces
{
    public interface IProductService
    {
        Product Get(string sku);
    }
}
