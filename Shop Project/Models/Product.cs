using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Product
    {
        [Key]
        public int P_id { get; set; }
        public int C_id { get; set; }
        public int S_id { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name cannot be longer than 100 characters.")]
        public string P_name { get; set; }

        [Required(ErrorMessage = "Product price is required.")]
        public string P_price { get; set; }
    }
}
