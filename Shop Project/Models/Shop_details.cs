using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Shop_details
    {
        [Key]
        public int S_id { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        public string S_location { get; set; }

        [Required(ErrorMessage = "PH is required.")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "PH must be exactly 10 digits.")]
        public string S_PH { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        public string S_Email { get; set; }
    }
}
