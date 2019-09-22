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
        /// Добавление или редактирование сотрудника
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("edit/{id?}")]
        public IActionResult Edit(int? id)
        {
            EmployeeView model;

            // Проверка введен ли ид
            if (id.HasValue)
            {
                model = _employeesData.GetById(id.Value);
                if (model is null)
                {
                    // возвращаем результат 404 Not Found
                    return NotFound();
                }
            }
            else
            {
                model = new EmployeeView();
            }
            return View(model);
        }

        [HttpPost]
        [Route("edit/{id?}")]
        public IActionResult Edit(EmployeeView model)
        {
            // Провкрка новый отрудник или у него уже есть ид
            if (model.Id > 0)
            {
                var dbItem = _employeesData.GetById(model.Id);
                if (dbItem is null)
                {
                    // возвращаем результат 404 Not Found
                    return NotFound(); 
                }
                    
                dbItem.FirstName = model.FirstName;
                dbItem.SurName = model.SurName;
                dbItem.Age = model.Age;
                dbItem.Patronymic = model.Patronymic;
                dbItem.DateBirth = model.DateBirth;
                dbItem.DateEmployment = model.DateEmployment;
            }
            else
            {
                // Добавлеям запись
                _employeesData.AddNew(model);
            }
            _employeesData.Commit();

            // Возвращаемся к списку
            return RedirectToAction(nameof(Index));
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

        /// <summary>
        /// Удаление сотрудника
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns></returns>
        [Route("delete/{id}")]
        public IActionResult Delete(int id)
        {
            _employeesData.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}