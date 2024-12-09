using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Complaint
    {
        [Key]
        public int Cm_id { get; set; }
        public int S_id { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string Cm_description { get; set; }

        public string Cm_reply { get; set; }
    }
}
