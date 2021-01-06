using System.Collections.Generic;
using AutoMapper;
using PcMAG2.Models.DTOs;
using PcMAG2.Models.Entities;
using PcMAG2.Repositories;

namespace PcMAG2.Services
{
    public class CartService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;

        public CartService(ICartItemRepository cartItemRepository, IMapper mapper)
        {
            _cartItemRepository = cartItemRepository;
            _mapper = mapper;
        }

        public bool CreateOrUpdateCartItemForUser(User user, CartItemDTO cartItemDto)
        {
            var cartItem = _cartItemRepository.FindById(user.UserId, cartItemDto.ProductId);
            // If item is already in user's cart
            if (cartItem != null)
            {
                if (cartItemDto.Quantity <= 0)
                {
                    _cartItemRepository.HardDelete(cartItem);
                }
                else // Update the quantity if != 0
                {
                    cartItem.Quantity = cartItemDto.Quantity;
                    _cartItemRepository.Update(cartItem);
                }
            }
            else // Else create new item
            {
                cartItem = _mapper.Map<CartItemDTO, CartItem>(cartItemDto);
                _cartItemRepository.Create(cartItem);
            }

            return _cartItemRepository.SaveChanges();
        }

        public List<CartItem> GetAllItemsForUser(User user)
        {
            return _cartItemRepository.FindAllByUserId(user.UserId);
        }
    }
}