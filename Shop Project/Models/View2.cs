using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class View2
    {
        public int P_id { get; set; }
        public int C_id { get; set; }
        public int S_id { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(100, ErrorMessage = "Location cannot be longer than 100 characters.")]
        public string S_location { get; set; }

        public int Sl_id { get; set; }
        public int Cu_id { get; set; }

        [Required(ErrorMessage = "Sale date is required.")]
        public string Sl_date { get; set; }

        [Required(ErrorMessage = "Product name is required.")]
        public string P_name { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public string P_price { get; set; }

        [Required(ErrorMessage = "Product detail is required.")]
        [StringLength(100, ErrorMessage = "Product detail cannot be longer than 100 characters.")]
        public string Sl_product { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Invalid amount; up to two decimal places are allowed.")]
        public string Sl_amount { get; set; }

        [Required(ErrorMessage = "Customer name is required.")]
        public string Cu_name { get; set; }

        public int O_id { get; set; }

        [Required(ErrorMessage = "Order product is required.")]
        public string O_product { get; set; }

        [Required(ErrorMessage = "Order date is required.")]
        public string O_date { get; set; }

        [Required(ErrorMessage = "Order quantity is required.")]
        public string O_quantity { get; set; }

        [Required(ErrorMessage = "Order status is required.")]
        public string O_status { get; set; }

        public int Cm_id { get; set; }

        [Required(ErrorMessage = "Complaint description is required.")]
        public string Cm_description { get; set; }

        [StringLength(500, ErrorMessage = "Reply cannot exceed 500 characters.")]
        public string Cm_reply { get; set; }
    }
}
