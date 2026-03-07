using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı girin.")]
        public required string userName { get; set; }

        [Required(ErrorMessage = "E-posta girin.")]
        public required string mail { get; set; }

        [Required(ErrorMessage = "Şifre girin.")]
        public required string password { get; set; }

        [Required(ErrorMessage = "Şifreyi tekrar girin.")]
        [Compare("password",ErrorMessage ="Girdiğiniz şifreler eşleşmiyor.")]
        public required string passwordConfirm { get; set; }
    }
}
