﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using storeapp.Data;
using storeapp.Data.Static;
using storeapp.Data.ViewModels;
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


        public IActionResult Login() => View(new LoginVM());

        public IActionResult Register() => View(new RegisterVM());

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.Email);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signinManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Item");
                    }
                }
                TempData["Error"] = "Wrong login or password.";
                return View(loginVM);
            }
            TempData["Error"] = "Wrong login or password.";
            return View(loginVM);
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            var user = await _userManager.FindByEmailAsync(registerVM.Email);
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use.";
                return View(registerVM);
            }
            var newUser = new ApplicationUser()
            {
                FullName = registerVM.Fullname,
                Email = registerVM.Email,
                UserName = registerVM.Email
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            };
            return View("RegisterComplete");

        }
        
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            return RedirectToAction("Index", "Item");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }

    }
}
