using storeapp.Data.Enums;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.Services
{
    public interface IOrderService
    {
        Task StoreOrderAsync(List<ShoppingCartItem> items, string userId, string userEmail);
        Task<List<Order>> GetOrderByUserIdAndRoleAsync(string UserId, string UserRole);
        Task <Order> GetOrderByIdAsync(int id);
        Task <Order> UpdateAsync(int id, Order order);
    }
}
