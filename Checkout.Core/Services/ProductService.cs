using System;
using System.Collections.Generic;
using System.Text;
using Checkout.Core.Entities;
using Checkout.Core.Interfaces;

namespace Checkout.Core.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }       

        public Product Get(string sku)
        {
            return _productRepository.Get(sku);
        }
    }
}
