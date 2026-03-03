using System.ComponentModel.DataAnnotations;

namespace AgriculturePresentation.Models
{
    public class ServiceAddViewModel
    {
        [Display(Name ="Başlık")]
        [Required(ErrorMessage ="Başlık boş bırakılamaz.")]
        public string? Title { get; set; }

        [Display(Name = "Görsel")]
        [Required(ErrorMessage = "Görsel alanı boş bırakılamaz.")]
        public string? Image { get; set; }

        [Display(Name = "Açıklama")]
        [Required(ErrorMessage = "Açıklama boş bırakılamaz.")]
        public string? Description { get; set; }
    }
}
