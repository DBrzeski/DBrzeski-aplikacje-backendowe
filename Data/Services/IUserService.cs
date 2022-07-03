using storeapp.Data.Base;
using storeapp.Data.Enums;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.Services
{
    public interface IUserService
    {
        Task <User> GetUserDataByUserId(string UserId);
        Task <User> UpdateAsync(int id, User newUser);
        Task AddAsync(User data);
    }
}
