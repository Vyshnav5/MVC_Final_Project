using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class LogShop
    {
        [Key]
        public int L_id { get; set; }

        [Required(ErrorMessage = "Shop code is required.")]
        [StringLength(10, ErrorMessage = "Shop code cannot be longer than 50 characters.")]
        public string S_shopcode { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string S_Password { get; set; }
        [Required]
        public string S_type { get; set; }
        public int S_id { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string S_location { get; set; }

        [Required(ErrorMessage = "PH is required.")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "PH must be exactly 10 digits.")]
        public string S_PH { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string S_Email { get; set; }
    }
}
