using Microsoft.EntityFrameworkCore;
using storeapp.Data.Base;
using storeapp.Data.Enums;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Order> GetOrderByIdAsync(int id)
        {
            var result = await _context.Orders.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async Task<List<Order>> GetOrderByUserIdAndRoleAsync(string userId, string userRole)
        {
            var orders = await _context.Orders.Include(n => n.OrderItems).ThenInclude(n => n.Item).Include(n => n.User).ToListAsync();

            if(userRole != "Admin")
            {
                orders = orders.Where(n => n.UserId == userId).ToList();
            }

            return orders;
        }

        public async Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmail,
                Status = Status.New
            };
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    ItemId = item.Item.Id,
                    OrderId = order.Id,
                    Price = item.Item.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Order> UpdateAsync(int id, Order newOrder)
        {
            _context.Update(newOrder);
            await _context.SaveChangesAsync();
            return newOrder;
        }
    }
}
