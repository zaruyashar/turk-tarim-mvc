namespace AgriculturePresentation.Models
{
    public class UserEditViewModel
    {
        public string? Mail { get; set; }
        public string? Phone { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public string? CurrentPassword { get; set; }
        public string? ImageUrl { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
