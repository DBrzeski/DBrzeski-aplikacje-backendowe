using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using storeapp.Data.Cart;
using storeapp.Data.Services;
using storeapp.Data.Static;
using storeapp.Data.ViewModels;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace storeapp.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IItemService _itemService;
        private readonly ShoppingCart _shoppingCart;
        private readonly IOrderService _orderService;

        public OrderController(IItemService itemService, ShoppingCart shoppingCart, IOrderService orderService)
        {
            _itemService = itemService;
            _shoppingCart = shoppingCart;
            _orderService = orderService;
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

        public async Task<IActionResult> Complete()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userEmail = User.FindFirstValue(ClaimTypes.Email);

            await _orderService.StoreOrderAsync(items, userId, userEmail);
            await _shoppingCart.ClearShoppingCartAsync();
            return View("OrderCompleted");
        }
        public async Task<IActionResult> Index()
        {
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = await _orderService.GetOrderByUserIdAndRoleAsync(userId,userRole);
            return View(orders);
        }
        [Authorize(Roles = UserRoles.Admin)]
        public async Task<IActionResult> Manage(int id)
        {
            var orderDetails = await _orderService.GetOrderByIdAsync(id);
            if (orderDetails == null) return View("NotFound");
            return View(orderDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Manage(int id,[Bind("Id,Status,Email,UserId")] Order order)
        {
            if (!ModelState.IsValid)
            {
                return View(order);
            }
            await _orderService.UpdateAsync(id, order);
            return RedirectToAction(nameof(Index));
        }
    }
}
