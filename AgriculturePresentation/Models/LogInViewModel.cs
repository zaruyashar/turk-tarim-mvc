using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class LogInViewModel
    {
        [Required(ErrorMessage ="Kullanıcı adını girin.")]
        public required string username { get; set; }

        [Required(ErrorMessage = "Şifreyi girin.")]
        public required string password { get; set; }
    }
}
