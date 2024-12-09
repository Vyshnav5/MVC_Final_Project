using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Category
    {
        [Key]
        public int C_id { get; set; }
        [Required(ErrorMessage = "Company Catogory is required.")]
        public string C_name { get; set; }
    }
}
