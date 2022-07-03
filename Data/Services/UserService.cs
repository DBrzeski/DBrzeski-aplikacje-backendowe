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
    public class UserService: IUserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(User data)
        {
            _context.User.Add(data);
            _context.SaveChanges();
        }

        public async Task<User> GetUserDataByUserId(string id)
        {
            var result = await _context.User.FirstOrDefaultAsync(n => n.UserId == id);
            return result;

        }

        public async Task<User> UpdateAsync(int id, User newUser)
        {
            _context.Update(newUser);
            await _context.SaveChangesAsync();
            return newUser;
        }
    }
}
