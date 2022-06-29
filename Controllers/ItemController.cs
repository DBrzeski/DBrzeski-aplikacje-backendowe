using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeapp.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemService _service;
        public ItemController(IItemService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allItems = await _service.GetAllAsync();
            return View(allItems);
        }
    }
}
