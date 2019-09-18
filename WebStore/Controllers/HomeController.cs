using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult ContactUs() {
            return View();
        }
        
        public IActionResult NotFound()
        {
            return View();
        }
    }
}