using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewsModels;

namespace WebStore.Controllers
{
    public class EmployeeController : Controller
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
                Age = 22,
                DateBirth = new DateTime(1997, 7, 20),
                DateEmployment = DateTime.Now,

    },
            new EmployeeView
            {
                Id = 2,
                FirstName = "Владислав",
                SurName = "Петров",
                Patronymic = "Иванович",
                Age = 35,
                DateBirth = new DateTime(1984, 5, 17),
                DateEmployment = DateTime.Now,
            },
            new EmployeeView
            {
                Id = 3,
                FirstName = "Алексей",
                SurName = "Аександров",
                Patronymic = "Петрович",
                Age = 35,
                DateBirth = new DateTime(1984, 8, 11),
                DateEmployment = DateTime.Now,
            }
        };



        // GET: Home
        public ActionResult Index()
        {
            return View(_employees);
        }

        // Вывод подробной информации и сотруднике
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return View(_employees.FirstOrDefault(x => x.Id == id));
        }
    }
}