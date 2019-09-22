using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.ViewsModels;

namespace WebStore.Controllers
{
    [Route("users")]
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



        /// <summary>
        /// Вывод списка сотрудников
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_employees);
        }

        /// <summary>
        /// Вывод подробной информации и сотруднике
        /// </summary>
        /// <param name="id">Id сотрудника</</param>
        /// <returns></returns>
        [Route ( "{id}" )]
        public ActionResult Details(int? id)
        {
            //Получаем сотрудника по Id
            var employee = _employees.FirstOrDefault(t => t.Id.Equals(id));

            //Если такого не существует
            if (employee is null)
            {
                //возвращаем результат 404 Not Found
                return NotFound();
            }
 
            //Иначе возвращаем сотрудника
            return View(employee);
        }
    }
}