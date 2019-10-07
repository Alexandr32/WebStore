using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Intefaces;
using WebStore.ViewsModels;

namespace WebStore.Infrastructure.Implementation
{
    /// <summary>
    /// Реализация интерфейса, хранит информацию в памяти
    /// </summary>
    public class InMemoryEmployeesData : IEmployeesData
    {

        private readonly List<EmployeeView> _employees;

        public InMemoryEmployeesData()
        {
            _employees = new List<EmployeeView>
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
        }

        public void AddNew(EmployeeView model)
        {
            // Указываем следующий id
            model.Id = _employees.Max(x => x.Id) + 1;
            _employees.Add(model);
        }

        public void Commit()
        {
            // ничего не делаем
        }

        public void Delete(int id)
        {
            // Находим сотрудника по id
            var employe = GetById(id);
            if (employe != null)
            {
                _employees.Remove(employe);
            }
        }

        public IEnumerable<EmployeeView> GetAll()
        {
            return _employees;
        }

        public EmployeeView GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }
    }
}
