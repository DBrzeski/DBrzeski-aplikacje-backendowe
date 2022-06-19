using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            var data = _context.Manufacturer.ToList();
            return View();
        }
    }
}
