using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeapp.Data;
using storeapp.Data.Services;
using storeapp.Data.Static;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _service;
        public ManufacturerController(IManufacturerService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,PictureUrl")]Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return View(manufacturer);
            }
            await _service.AddAsync(manufacturer);
            return RedirectToAction(nameof(Index));
        }
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);

            if (manufacturerDetails == null) return View("NotFound");
            return View(manufacturerDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null) return View("NotFound");
            return View(manufacturerDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,PictureUrl")] Manufacturer manufacturer)
        {
            if (!ModelState.IsValid)
            {
                return View(manufacturer);
            }
            await _service.UpdateAsync(id, manufacturer);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null) return View("NotFound");
            return View(manufacturerDetails);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manufacturerDetails = await _service.GetByIdAsync(id);
            if (manufacturerDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
