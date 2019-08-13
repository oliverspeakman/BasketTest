using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkout.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CheckoutServerWeb.Controllers
{    
    [ApiController]
    public class BasketController : ControllerBase
    {
        private IBasketService _basketService;

        public BasketController(IBasketService basketService)
        {
            _basketService = basketService;
        }

        [Route("api/basket/totalPrice")]
        [HttpGet]
        public JsonResult TotalPrice(List<string> sku)
        {
            return new JsonResult(_basketService.CalculateTotalPrice(sku));
        }
       
        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}        
    }
}
