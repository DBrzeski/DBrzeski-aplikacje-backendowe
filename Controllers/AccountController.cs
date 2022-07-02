using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using storeapp.Data;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace storeapp.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly AppDbContext _context;


        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signinManager, AppDbContext context)
        {
            _userManager = userManager;
            _signinManager = signinManager;
            _context = context;
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
