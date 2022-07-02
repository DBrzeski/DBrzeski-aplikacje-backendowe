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

        public void AddItemToCart(Item item)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Item.Id == item.Id && n.ShoppingCartId == ShoppingCartId);
            if(shoppingCartItem == null)
            {
                shoppingCartItem = new ShoppingCartItem()
                {
                    ShoppingCartId = ShoppingCartId,
                    Item = item,
                    Amount = 1
                };
                _context.ShoppingCartItems.Add(shoppingCartItem);
            }
            else
            {
                shoppingCartItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromCart(Item item)
        {
            var shoppingCartItem = _context.ShoppingCartItems.FirstOrDefault(n => n.Item.Id == item.Id && n.ShoppingCartId == ShoppingCartId);
            if (shoppingCartItem != null)
            {
                shoppingCartItem = new ShoppingCartItem();
                
                    if(shoppingCartItem.Amount > 1)
                    {
                        shoppingCartItem.Amount--;
                    }
                    else
                    {
                        _context.ShoppingCartItems.Remove(shoppingCartItem);
                    }
                
            }
            _context.SaveChanges();
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
