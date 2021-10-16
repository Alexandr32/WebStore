using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewsModels
{
    // ViewModel для регистрации пользователя
    public class RegisterUserViewModel
    {
        // Имя пользователя
        [Required(AllowEmptyStrings=false, ErrorMessage="Поле является обязательным"), MaxLength(255)]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        // Почта
        [Display(Name = "Электронная почта")]
        [Required(AllowEmptyStrings=false, ErrorMessage="Поле является обязательным"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Пароль
        [Required(AllowEmptyStrings=false, ErrorMessage="Поле является обязательным"), DataType(DataType.Password)]
        [Display(Name="Пароль")]
        public string Password { get; set; }

        // Подтверждение пароля
        // Compare(nameof(Password)) - связывание с полем пароля
        [Required(AllowEmptyStrings=false, ErrorMessage="Поле является обязательным"), DataType(DataType.Password), Compare(nameof(Password), ErrorMessage="Пароли не совпадает")]
        [Display(Name="Подтверждение пароля")]
        public string ConfirmPassword { get; set; }
    }
}
