using System.ComponentModel.DataAnnotations;

namespace AvioLine.Domain.Models.Account
{
    public class RegisterUserViewModel
    {
        [Required]
        [MaxLength(255)]
        [Display(Name ="Email пользователя")]
        public string Email { get; set; }



        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Пароль")]
        public string Password { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пороля")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
