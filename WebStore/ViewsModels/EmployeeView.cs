using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewsModels
{
    public class EmployeeView
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        [Display(Name = "Имя")]
        public string FirstName { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        [Display(Name = "Фамилия")]
        public string SurName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        [Display(Name = "Отчество")]
        public string Patronymic { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateBirth { get; set; }
        /// <summary>
        /// Дата трудоустройства
        /// </summary>
        [Display(Name = "Дата трудоустройства")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateEmployment { get; set; }
    }
}
