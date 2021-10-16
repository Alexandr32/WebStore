using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewComponents
{
    /// <summary>
    /// ViewComponent, который отображает ссылку на вход/регистрацию или ссылку на выход.
    /// </summary>
    public class LoginLogoutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
