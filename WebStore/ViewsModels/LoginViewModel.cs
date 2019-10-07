using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ViewsModels
{
    /// <summary>
    /// ViewModel для входа в акаунт
    /// </summary>
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле является обязательным")]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Поле является обязательным"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня")]
        public bool RememberMe { get; set; }

        // ССылка на которую пытался зайти пользователь
        public string ReturnUrl { get; set; }
    }
}
