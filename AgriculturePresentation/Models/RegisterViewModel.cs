using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girin.")]
        public required string UserName { get; set; }

        [Required(ErrorMessage = "E-posta girin.")]
        public required string Mail { get; set; }

        [Required(ErrorMessage = "Şifre girin.")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Şifreyi tekrar girin.")]
        [Compare(nameof(Password), ErrorMessage = "Girdiğiniz şifreler eşleşmiyor.")]
        public required string PasswordConfirm { get; set; }
    }
}