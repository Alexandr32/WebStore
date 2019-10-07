using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebStore.DomainNew.Entities;
using WebStore.ViewsModels;

namespace WebStore.Controllers
{
    // Контролер для регестрации и входа пользователя
    public class AccountController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        // Внедряем зависимости
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        // Вход пользоватля
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Регестарция пользователя
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Cоздаем сущность пользователь
                var user = new User 
                { 
                    UserName = model.UserName,
                    Email = model.Email
                };

                // Используем менеджер для создания
                var createResult = await userManager.CreateAsync(user, model.Password);

                if (createResult.Succeeded)
                {
                    // Если успешно -производим логин
                    await signInManager.SignInAsync(user, false); 
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // Выводим ошибки
                    foreach (var identityError in createResult.Errors)
                    {
                        ModelState.AddModelError("", identityError.Description);
                    }
                }
            }

            return View(model);
        }

        /// <summary>
        /// Выход из акаунта
        /// </summary>
        /// <returns></returns>
        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
