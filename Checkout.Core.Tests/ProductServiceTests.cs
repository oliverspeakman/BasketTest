using Checkout.Core.Entities;
using Checkout.Core.Interfaces;
using Checkout.Core.Repositories;
using Checkout.Core.Services;
using Checkout.Core.Tests.Helpers;
using NUnit.Framework;

namespace Checkout.Core.Tests
{
    public class ProductServiceTests
    {
        private IProductService _serviceToTest;
        [SetUp]
        public void Setup()
        {
            IProductRepository productRepository = new ProductRepository();
            _serviceToTest = new ProductService(productRepository);
        }

        [Test]
        public void GetProduct_InvalidProduct_NullReturned()
        {           
            var fetchedProduct = _serviceToTest.Get("INVALID");

            Assert.IsNull(fetchedProduct);            
        }

        [Test]
        public void GetProduct_ValidProduct_ProductReturned()
        {                                   
            var fetchedProduct = _serviceToTest.Get("A99");

            Assert.AreEqual("A99",fetchedProduct.Sku);
            Assert.AreEqual("Apple", fetchedProduct.Description);
            Assert.AreEqual(0.5M,fetchedProduct.UnitPrice);
        }
        
    }
}