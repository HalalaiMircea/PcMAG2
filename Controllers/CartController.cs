using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PcMAG2.Helpers;
using PcMAG2.Models.Entities;
using PcMAG2.Services;

namespace PcMAG2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartService _cartService;

        public CartController(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult GetAll()
        {
            var user = GetUserFromContext();
            return Ok(_cartService.GetAllItemsForUser(user));
        }

        [HttpPut("{productId}")]
        [Authorize]
        public IActionResult AddCartItem(long productId)
        {
            try
            {
                var result = _cartService.AddCartItemForUser(GetUserFromContext(), productId);
                return Ok(result);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound("Product with id " + productId + " doesn't exist");
            }
        }

        [HttpPatch("{productId}")]
        [Authorize]
        public IActionResult ModifyQuantity(long productId, [FromBody] int quantity)
        {
            try
            {
                var result = _cartService.UpdateCartItemQty(GetUserFromContext(), productId, quantity);
                return Ok(result);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(new {e.Message});
            }
            catch (ArgumentException e)
            {
                return BadRequest(new {e.Message});
            }
        }

        [HttpDelete("{productId}")]
        [Authorize]
        public IActionResult RemoveCartItem(long productId)
        {
            try
            {
                var result = _cartService.RemoveCartItemForUser(GetUserFromContext(), productId);
                return Ok(result);
            }
            catch (KeyNotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        private User GetUserFromContext()
        {
            return (User) HttpContext.Items["User"]!;
        }
    }
}