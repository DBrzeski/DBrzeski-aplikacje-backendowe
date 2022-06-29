using Microsoft.EntityFrameworkCore;
using storeapp.Data.Base;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Data.Services
{
    public class ItemService: EntityBaseRepository<Item>, IItemService
    {
        private readonly AppDbContext _context;
        public ItemService(AppDbContext context):base(context)
        {
            _context = context;
        }

        //public Task<Item> GetMovieByIdAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}



        public async Task<Item> GetItemByIdAsync(int id)
        {
            var itemDetails = _context.Item
                .Include(m => m.Manufacturer).FirstOrDefaultAsync(n => n.Id == id);
            return await itemDetails;
        }
    }
}
