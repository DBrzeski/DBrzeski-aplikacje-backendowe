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


        public async Task<IActionResult> Edit(int id)
        {
            var itemDetails = await _service.GetItemByIdAsync(id);
            if (itemDetails == null) return View("NotFound");
            var response = new NewItemVM()
            {
                Name = itemDetails.Name,
                Description = itemDetails.Description,
                Price = itemDetails.Price,
                ItemCategory = itemDetails.ItemCategory,
                ManufacturerId = itemDetails.ManufacturerId,
                PictureUrl = itemDetails.PictureUrl,
                Id = itemDetails.Id
            };

            var itemDropdownsData = await _service.GetNewItemDropdownsValues();
            ViewBag.ManufacturerId = new SelectList(itemDropdownsData.Manufacturer, "Id", "Name");
            return View(response);
        }
        [HttpPost]

        public async Task<IActionResult> Edit(int id, NewItemVM item)
        {
            if (id != item.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var itemDropdownsData = await _service.GetNewItemDropdownsValues();
                ViewBag.ManufacturerId = new SelectList(itemDropdownsData.Manufacturer, "Id", "Name");

                return View(item);
            }
            await _service.UpdateItemAsync(item);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allItems = await _service.GetAllAsync(n => n.Manufacturer);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResults = allItems.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index",  filteredResults);
            }

            return View("Index");
        }

    }
}
