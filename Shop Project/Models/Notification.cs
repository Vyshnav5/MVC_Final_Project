using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Notification
    {
        [Key]
        public int N_id { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string N_description { get; set; }
        [Required(ErrorMessage = "Date is required.")]
        public string N_date { get; set; }
    }
}
