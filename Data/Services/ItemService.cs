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
        public ItemService(AppDbContext context):base(context)
        {

        }
    }
}
