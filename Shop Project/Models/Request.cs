using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Request
    {
        [Key]
        public int R_id { get; set; }

        public int S_id { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        public string R_description { get; set; }

        public string R_reply { get; set; }
    }
}
