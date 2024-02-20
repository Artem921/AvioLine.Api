using System.ComponentModel.DataAnnotations;

namespace AvioLine.Domain.Models.Account
{
    public class LoginUserViewModel
    {
        [Required]
        [MaxLength(255)]
        [Display(Name = "Имя пользователя")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name ="Запомнить меня")]
        public bool RememberMe { get; set; }

       
        public string? ReturnUrl { get; set; }
    }
}
