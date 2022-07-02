using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace storeapp.Data.Cart
{
    public class ShoppingCart
    {
        public AppDbContext _context { get; set; }

        public string ShoppingCartId { get; set; }
        public List<ShoppingCartItem> ShoppingCartItem { get; set; }
        public ShoppingCart(AppDbContext context)
        {
            _context = context;
        }


        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            return ShoppingCartItem ?? (ShoppingCartItem = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Include(n => n.Item).ToList());
        }
        public double GetShoppingCartTotal()
        {
            var total = _context.ShoppingCartItems.Where(n => n.ShoppingCartId == ShoppingCartId).Select(n => n.Item.Price * n.Amount).Sum();
            return total;
        }



    }
}
