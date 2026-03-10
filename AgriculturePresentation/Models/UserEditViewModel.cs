namespace AgriculturePresentation.Models
{
    public class UserEditViewModel
    {
        public required string Mail { get; set; }
        public required string Phone { get; set; }
        public required string Password { get; set; }
        public required string ConfirmPassword { get; set; }
        public required string CurrentPassword { get; set; }
    }
}
