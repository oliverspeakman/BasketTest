using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Checkout.Core.Entities;
using Checkout.Core.Interfaces;
using Checkout.Core.Repositories;
using Checkout.Core.Services;
using Moq;
using NUnit.Framework;

namespace Checkout.Core.Tests
{
    [TestFixture]
    class BasketServiceTests
    {
        private IBasketService _serviceToTest;

        [SetUp]
        public void Setup()
        {
            _serviceToTest = new BasketService(new OfferService(new OfferRepository()),new ProductService(new ProductRepository()));
        }

        [Test]
        public void CalculateTotalPrice_EmptyBasket_PriceIsZero()
        {
            var skus = new List<string>();

            var price = _serviceToTest.CalculateTotalPrice(skus);

            Assert.AreEqual(0,price);
        }

        [Test]
        public void CalculateTotalPrice_InvalidProducts_PriceIsZero()
        {
            var skus = new List<string>()
            {
                "",
                "Invalid",
                "Z99"
            };


            var price = _serviceToTest.CalculateTotalPrice(skus);

            Assert.AreEqual(0, price);
        }

        [Test]
        public void CalculateTotalPrice_WrongCaseProducts_PriceIsZero()
        {
            var skus = new List<string>()
            {
                "a99",
                "b15"
                
            };
            var price = _serviceToTest.CalculateTotalPrice(skus);

            Assert.AreEqual(0, price);
        }

        [Test]
        public void CalculateTotalPrice_SingleValidProductNoOffer_PriceIsCorrect()
        {
            var skus = new List<string>()
            {
                "A99"
            };
            var price = _serviceToTest.CalculateTotalPrice(skus);

            Assert.AreEqual(0.5M, price);
        }

        [Test]
        public void CalculateTotalPrice_TwoMatchingProductsNoOffer_PriceIsCorrect()
        {
            var skus = new List<string>()
            {
                "A99",
                "A99"
            };
            var price = _serviceToTest.CalculateTotalPrice(skus);

            Assert.AreEqual(0.5M * 2, price);
        }

        [Test]
        public void CalculateTotalPrice_ThreeMatchingProductsOnOffer_PriceIsCorrect()
        {
            var skus = new List<string>()
            {
                "A99",
                "A99",
                "A99"
            };
            var price = _serviceToTest.CalculateTotalPrice(skus);

            Assert.AreEqual(1.3M, price);
        }

        [Test]
        public void CalculateTotalPrice_FourMatchingProductsOnOffer_PriceIsCorrect()
        {
            var skus = new List<string>()
            {
                "A99",
                "A99",
                "A99",
                "A99"

            };
            var price = _serviceToTest.CalculateTotalPrice(skus);

            Assert.AreEqual(1.8M, price);
        }
    }
}
