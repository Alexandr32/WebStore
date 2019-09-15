using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewsModels;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        // Создаем модель
        private readonly List<EmployeeView> _employees = new List<EmployeeView>
        {
            new EmployeeView
            {
                Id = 1,
                FirstName = "Иван",
                SurName = "Иванов",
                Patronymic = "Иванович",
                Age = 22
            },
            new EmployeeView
            {
                Id = 2,
                FirstName = "Владислав",
                SurName = "Петров",
                Patronymic = "Иванович",
                Age = 35
            },
            new EmployeeView
            {
                Id = 3,
                FirstName = "Алексей",
                SurName = "Аександров",
                Patronymic = "Петрович",
                Age = 35
            }
        };



        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}