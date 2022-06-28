using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using storeapp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Controllers
{
    public class ManufacturerController : Controller
    {
        private readonly AppDbContext _context;
        public ManufacturerController(AppDbContext context)
        {
            _context = context;
        }
        public async  Task<IActionResult> Index()
        {
            var data = await _context.Manufacturer.ToListAsync();
            return View(data);
        }
    }
}
