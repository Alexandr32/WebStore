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
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Shop() {
            return View();
        }
        public IActionResult ProductDetails()
        {
            return View();
        }
        public IActionResult Login() {
            return View();
        }
        public IActionResult ContactUs() {
            return View();
        }
        public IActionResult Checkout() {
            return View();
        }
        public IActionResult Cart() {
            return View();
        }
    
        public IActionResult NotFound()
        {
            return View();
        }
    }
}