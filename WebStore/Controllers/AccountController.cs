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
    /// <summary>
    /// Контроллер для регестрации и входа пользователя
    /// </summary>
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

        /// <summary>
        /// Вход пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Проверяем логин/пароль пользователя
                var loginResult = await signInManager.PasswordSignInAsync(
                    model.UserName, 
                    model.Password, 
                    model.RememberMe,
                    lockoutOnFailure: false);

                // Проверяем пользователя
                if (loginResult.Succeeded)
                {
                    // Если returnUrl - локальный
                    if (Url.IsLocalUrl(model.ReturnUrl)) 
                    {
                        // Перенаправляем туда, откуда пришли
                        return Redirect(model.ReturnUrl); 
                    }
                    // Иначе на главную
                    return RedirectToAction("Index", "Home"); 
                }
            }

            // Говорим пользователю, что вход невозможен
            ModelState.AddModelError("", "Вход невозможен"); 
            return View(model);
        }

        /// <summary>
        /// Регестарция нового пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterUserViewModel());
        }

        /// <summary>
        /// Регестарция новго пользователя
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
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