using System.ComponentModel.DataAnnotations;

namespace Identity1.Models.ViewModel
{
    public class LoginVM
    {
        
        [Required]
        [MaxLength(40)]
        [Display (Name = "User Name")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MaxLength (35)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
