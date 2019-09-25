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
        [ Required ( AllowEmptyStrings = false , ErrorMessage = "Имя является обязательным" )]
        [StringLength(maximumLength: 200, MinimumLength = 2, ErrorMessage = "В имени должно быть не менее 2х и не более 200 символов" )]
        [Display(Name = "Имя")]
        public string FirstName { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Фамилия является обязательной" )]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Возраст является обязательным")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Дата рождения является обязательным")]
        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateBirth { get; set; }

        /// <summary>
        /// Дата трудоустройства
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Дата трудоустройства является обязательным")]
        [Display(Name = "Дата трудоустройства")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}")]
        [DataType(DataType.Date)]
        public DateTime DateEmployment { get; set; }
    }
}
