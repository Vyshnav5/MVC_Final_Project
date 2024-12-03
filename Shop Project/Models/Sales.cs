using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class Sales
    {
        [Key]   
        public int Sl_id { get; set; }
        public int S_id { get; set; }
        public int P_id { get; set; }
        public int Cu_id { get; set; }
  

        public string Sl_date { get; set; }
    }
}
