using storeapp.Data.Base;
using storeapp.Data.ViewModels;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.Services
{
    public interface IItemService:IEntityBaseRepository<Item>
    {
        Task<Item> GetItemByIdAsync(int id);
        Task<NewItemDropdownsVM> GetNewItemDropdownsValues();
    }
}
