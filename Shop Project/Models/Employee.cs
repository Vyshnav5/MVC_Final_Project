using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Employee
    {
        [Key]
        public int E_id { get; set; }
        public int S_id { get; set; }

        [Required(ErrorMessage = "Employee name is required.")]
        [StringLength(30, ErrorMessage = "Name cannot be longer than 30 characters.")]
        public string E_name { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression("[0-9]{10}", ErrorMessage = "Phone number must be exactly 10 digits.")]
        public string E_ph { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string E_email { get; set; }

        [Required(ErrorMessage = "Position is required.")]
        [StringLength(50, ErrorMessage = "Position cannot be longer than 50 characters.")]
        public string E_position { get; set; }
    }
}
