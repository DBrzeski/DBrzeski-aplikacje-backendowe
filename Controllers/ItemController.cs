using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var allItems = await _service.GetAllAsync(n => n.Manufacturer);
            return View(allItems);
        }
        public async Task<IActionResult> Details(int id)
        {
            var itemDetail = await _service.GetItemByIdAsync(id);
            return View(itemDetail);
        }
        public async Task<IActionResult> Create()
        {
            var itemDropdownsData = await _service.GetNewItemDropdownsValues();
            ViewBag.ManufacturerId = new SelectList(itemDropdownsData.Manufacturer, "Id", "Name");
            return View();
        }
    }
}
