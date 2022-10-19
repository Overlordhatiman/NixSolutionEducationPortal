﻿using MainProject.BL.DTO;
using MainProject.BL.Interfaces;
using MainProject.UI.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MainProject.UI.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserService userService;
        public AccountController(IUserService service)
        {
            userService = service;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(model == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                UserDTO user = await userService.GetUser(model.Email, model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await userService.AddUser(new UserDTO { Mail = model.Email, Password = model.Password });

                await Authenticate(model.Email);

                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private async Task Authenticate(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var user = await userService.GetUser(User.Identity.Name);
            var userSkills = await userService.GetSkills(user.Id);
            List<Tuple<int, string>> values = new List<Tuple<int, string>>();
            foreach (var item in userSkills)
            {
                values.Add(new Tuple<int, string>(item.LevelOfSkill, item.Skill.Name));
            }
            ViewBag.Skills = values;

            return View(user);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
