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
        [Required, MaxLength(2)]
        public string UserName { get; set; }

        // Почта
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        // Пароль
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        // Подтверждение пароля
        // Compare(nameof(Password)) - связывание с полем пароля
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
