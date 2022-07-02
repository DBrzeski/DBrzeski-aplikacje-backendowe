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
    }
}
