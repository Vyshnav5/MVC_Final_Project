using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Customer
    {
        [Key]
        public int Cu_id { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        [StringLength(30, ErrorMessage = "Customer name cannot be longer than 30 characters.")]
        public string Cu_name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string Cu_ph { get; set; }
    }
}
