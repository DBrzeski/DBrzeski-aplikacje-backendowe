using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using storeapp.Data.Services;
using storeapp.Models;
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
        [HttpPost]

        public async Task<IActionResult> Create(NewItemVM item)
        {
            if (!ModelState.IsValid)
            {
                var itemDropdownsData = await _service.GetNewItemDropdownsValues();
                ViewBag.ManufacturerId = new SelectList(itemDropdownsData.Manufacturer, "Id", "Name");

                return View(item);
            }
            await _service.AddNewItemAsync(item);
            return RedirectToAction(nameof(Index));
        }
    }
}
