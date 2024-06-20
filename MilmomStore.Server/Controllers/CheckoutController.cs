using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.Json;
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
        
        [HttpPost("createOrder")]
        [ProducesResponseType(StatusCodes.Status302Found)]
        public async Task<string>  CreateOrder(string accountId, [FromBody] ShippingRequest shippingRequest)
        {
            var amount = await _checkoutService.GetAmount(accountId);
            var order = await _checkoutService.Checkout(accountId, shippingRequest);
            var orderId = order.OrderID;
            // create payment vnpay
            var vnPayModel = new VnPayRequestModel
            {
                Amount = amount,
                CreatedDate = DateTime.Now,
                Description = $"{shippingRequest.ReceiverName} {shippingRequest.Phone}",
                FullName = shippingRequest.ReceiverName,
                OrderId = orderId,
                OrderInfor = JsonSerializer.Serialize(new {AccountId = accountId, ShippingRequest = shippingRequest})
            };
            return _vnPayService.CreatePaymentUrl(HttpContext, vnPayModel);
        }
        
        [HttpGet("vnpay-return")]
        public async Task<IActionResult> HandleVnPayReturn([FromQuery] VnPayReturnModel model)
        {
            if (model.Vnp_TransactionStatus != "00") return BadRequest();
            var transaction = new Transaction
            {
                Amount = model.Vnp_Amount,
                BankCode = model.Vnp_BankCode,
                BankTranNo = model.Vnp_BankTranNo,
                TransactionType = model.Vnp_CardType,
                OrderInfo = model.Vnp_OrderInfo,
                PayDate = DateTime.ParseExact((string)model.Vnp_PayDate, "yyyyMMddHHmmss", CultureInfo.InvariantCulture),
                ResponseCode = model.Vnp_ResponseCode,
                TmnCode = model.Vnp_TmnCode,
                TransactionNo = model.Vnp_TransactionNo,
                TransactionStatus = model.Vnp_TransactionStatus,
                TxnRef = model.Vnp_TxnRef,
                SecureHash = model.Vnp_SecureHash,
                ResponseId = model.Vnp_TransactionNo,
                Message = model.Vnp_ResponseCode
            };
            var order = await _checkoutService.CreateOrder(Convert.ToInt32(model.Vnp_OrderInfo), transaction);
            return Ok(order);
        }
        
        
    }
}