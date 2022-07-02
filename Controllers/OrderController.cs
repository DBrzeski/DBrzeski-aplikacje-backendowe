using Microsoft.AspNetCore.Mvc;
using storeapp.Data.Cart;
using storeapp.Data.Services;
using storeapp.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Controllers
{
    public class OrderController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IItemService itemService, ShoppingCart shoppingCart)
        {
            _itemService = itemService;
            _shoppingCart = shoppingCart;
        }
        public IActionResult ShoppingCart()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItem = items;
            var response = new ShoppingCartVM()
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddToShoppingCart(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.AddItemToCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
        public async Task<IActionResult> RemoveFromShoppingCart(int id)
        {
            var item = await _itemService.GetItemByIdAsync(id);

            if (item != null)
            {
                _shoppingCart.RemoveItemFromCart(item);
            }
            return RedirectToAction(nameof(ShoppingCart));
        }
    }
}
