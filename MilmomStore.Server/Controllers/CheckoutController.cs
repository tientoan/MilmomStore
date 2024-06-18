using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.Request.ShippingRequest;
using Milmom_Service.Model.Request.VnPayModel;
using Milmom_Service.Service;
using MilmomStore_BusinessObject.Model;

namespace MilmomStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutService _checkoutService;
        private readonly IVnPayService _vnPayService;
        
        public CheckoutController(ICheckoutService checkoutService, IVnPayService vnPayService)
        {
            _checkoutService = checkoutService;
            _vnPayService = vnPayService;
            
        }
        //
        [HttpGet("{accountId}")]
        public async Task<IActionResult> Checkout(string accountId)
        {
            var validationResult = await _checkoutService.ValidateCart(accountId);
            if (validationResult == false)
            {
                return BadRequest("Cart is empty or invalid");
            }
            return Ok();
        }
        [HttpPost("{accountId}")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<string> CreateOrder(string accountId, [FromBody] ShippingRequest shippingRequest)
        {
            var amount = await _checkoutService.GetAmount(accountId);
            //vnpay method
            var vnPayModel = new VnPayRequestModel
            {
                Amount = amount,
                CreatedDate = DateTime.Now,
                Description = $"{shippingRequest.ReceiverName} {shippingRequest.Phone}",
                FullName = shippingRequest.ReceiverName,
                OrderId = new Random().Next(10,100)
            };
            return _vnPayService.CreatePaymentUrl(HttpContext, vnPayModel);
            //var order = await _checkoutService.CreateOrder(accountId, shippingRequest);
            //return Ok(order);
        }
            
    }
}