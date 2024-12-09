using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Expense
    {
        [Key]
        public int Ex_id { get; set; }

        public int S_id { get; set; }

        [Required(ErrorMessage = "Expense type is required.")]
        public string Ex_type { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        public string Ex_date { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        public string Ex_amount { get; set; }
    }
}
