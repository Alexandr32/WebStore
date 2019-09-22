using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Intefaces;
using WebStore.ViewsModels;

namespace WebStore.Controllers
{
    [Route("users")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeesData _employeesData;

        public EmployeeController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }

        /// <summary>
        /// Вывод списка сотрудников
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(_employeesData.GetAll());
        }

        /// <summary>
        /// Вывод подробной информации и сотруднике
        /// </summary>
        /// <param name="id">Id сотрудника</</param>
        /// <returns></returns>
        [Route ( "{id}" )]
        public ActionResult Details(int id)
        {
            // Получаем сотрудника по Id
            var employee = _employeesData.GetById(id);

            // Если такого не существует
            if (employee is null)
            {
                //возвращаем результат 404 Not Found
                return NotFound();
            }
 
            // Иначе возвращаем сотрудника
            return View(employee);
        }
    }
}