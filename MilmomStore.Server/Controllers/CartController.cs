using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Milmom_Service.IService;
using Milmom_Service.Model.BaseResponse;
using Milmom_Service.Model.Request.Cart;
using Milmom_Service.Model.Response.Cart;

namespace MilmomStore.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }
        //
        
        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] CartRequest request)
        {
            await _cartService.AddToCart(request.AccountId, request.ProductId);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFromCart([FromBody] CartRequest request)
        {
            await _cartService.RemoveFromCart(request.AccountId, request.ProductId);
            return Ok();
        }

        [HttpGet("{accountId}")]
        public async Task<ActionResult<BaseResponse<CartResponse>>> GetCart(string accountId)
        {
            var cart = await _cartService.GetCart(accountId);
            return Ok(cart);
        }

        [HttpDelete("{accountId}")]
        public async Task<IActionResult> ClearCart(string accountId)
        {
            await _cartService.ClearCart(accountId);
            return Ok();
        }
    }
}
