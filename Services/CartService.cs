using System;
using System.Collections.Generic;
using AutoMapper;
using PcMAG2.Models.Entities;
using PcMAG2.Repositories;

namespace PcMAG2.Services
{
    public class CartService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public CartService(ICartItemRepository cartItemRepository, IMapper mapper, IProductRepository productRepository)
        {
            _cartItemRepository = cartItemRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public List<CartItem> AddCartItemForUser(User user, long productId)
        {
            if (_productRepository.FindById(productId) == null) throw new KeyNotFoundException();

            var cartItem = _cartItemRepository.FindById(user.UserId, productId);
            if (cartItem == null)
            {
                _cartItemRepository.Create(new CartItem
                {
                    UserId = user.UserId,
                    ProductId = productId,
                    Quantity = 1
                });
            }
            else // If it already exists, we increment quantity
            {
                cartItem.Quantity++;
                _cartItemRepository.Update(cartItem);
            }

            _cartItemRepository.SaveChanges();
            return GetAllItemsForUser(user);
        }

        public List<CartItem> UpdateCartItemQty(User user, long productId, long qty)
        {
            var cartItem = _cartItemRepository.FindById(user.UserId, productId);
            if (cartItem == null)
                throw new KeyNotFoundException("Product not found in user's cart");

            if (qty <= 0) throw new ArgumentException("Quantity must be higher than 0");

            cartItem.Quantity = qty;
            _cartItemRepository.Update(cartItem);
            _cartItemRepository.SaveChanges();

            return GetAllItemsForUser(user);
        }

        public List<CartItem> RemoveCartItemForUser(User user, long productId)
        {
            var cartItem = _cartItemRepository.FindById(user.UserId, productId);
            if (cartItem == null)
                throw new KeyNotFoundException("Product not found in user's cart");
            _cartItemRepository.HardDelete(cartItem);
            _cartItemRepository.SaveChanges();

            return GetAllItemsForUser(user);
        }

        public List<CartItem> GetAllItemsForUser(User user)
        {
            return _cartItemRepository.FindAllByUserId(user.UserId);
        }
    }
}