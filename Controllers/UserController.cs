using Microsoft.AspNetCore.Mvc;
using storeapp.Data.Services;
using storeapp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace storeapp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<IActionResult> Profile()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserDataByUserId(userId);
            if (user != null)
            {
                return View(user);
            }
            User newUser = new User()
            {
                UserId = userId
            };
            await _userService.AddAsync(newUser);
            user = await _userService.GetUserDataByUserId(userId);
            return RedirectToAction("Edit", "User");

        }
        public async Task<IActionResult> Edit()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetUserDataByUserId(userId);
            if (user != null)
            {
                return View(user);
            }
            User newUser = new User()
            {
                UserId = userId
            };
            await _userService.AddAsync(newUser);
            user = await _userService.GetUserDataByUserId(userId);
            return RedirectToAction("Edit", "User");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Phone,Street,Number,Postal,Province,City")] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            await _userService.UpdateAsync(id, user);
            return RedirectToAction(nameof(Profile));
        }
    }
}
