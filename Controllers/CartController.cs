using Microsoft.AspNetCore.Mvc;
using PcMAG2.Helpers;
using PcMAG2.Models.DTOs;
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
        public IActionResult GetCartItems()
        {
            var user = GetUserFromContext();
            return Ok(_cartService.GetAllItemsForUser(user));
        }

        [HttpPut]
        [Authorize]
        public IActionResult PutCartItem(CartItemDTO payload)
        {
            return Ok(_cartService.CreateOrUpdateCartItemForUser(GetUserFromContext(), payload));
        }

        private User GetUserFromContext()
        {
            return (User) HttpContext.Items["User"]!;
        }
    }
}