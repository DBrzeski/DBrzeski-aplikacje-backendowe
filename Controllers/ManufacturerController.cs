using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeapp.Data;
using storeapp.Data.Services;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly IManufacturerService _service;
        public ManufacturerController(IManufacturerService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAll();
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
            _service.Add(manufacturer);
            return RedirectToAction(nameof(Index));
        }
    }
}
