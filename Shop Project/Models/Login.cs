using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Login
    {
        [Key]
        public int L_id { get; set; }
        public int S_id { get; set; }

        [Required(ErrorMessage = "Shop code is required.")]
        [StringLength(10, ErrorMessage = "Shop code cannot be longer than 10 characters.")]
        public string S_shopcode { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [StringLength(10, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
        public string S_Password { get; set; }

        [Required]
        public string S_type { get; set; }
    }
}
