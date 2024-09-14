using System.ComponentModel.DataAnnotations;

namespace Identity1.Models.ViewModel
{
    public class RegisterVM
    {
        [Required]
        [MaxLength (35)]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength (50)]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength (40)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength(40)]
        [Compare (nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string? PhoneNumber { get; set; }
    }
}
