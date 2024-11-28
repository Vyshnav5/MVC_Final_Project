using System;
using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Order
    {
        [Key]
        public int O_id { get; set; }
        public int S_id { get; set; }
        public int P_id { get; set; }
        [Required(ErrorMessage = "Order date is required.")]
        public string O_date { get; set; }
        [Required(ErrorMessage = "Quantity is required.")]
        public string O_quantity { get; set; }
        public string O_status { get; set; }
    }
}
