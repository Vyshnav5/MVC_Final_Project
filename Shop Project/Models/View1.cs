using System.ComponentModel.DataAnnotations;

namespace Shop_Project.Models
{
    public class View1
    {
        public int S_id { get; set; }    
        public string S_location { get; set; }
        public string S_PH { get; set; }
        public string S_Email { get; set; }
        public int E_id { get; set; }
        public string E_name { get; set; }
        public string E_ph { get; set; }
        public string E_email { get; set; }
        public string E_position { get; set; }
        public int C_id { get; set; }
        public string C_name { get; set; }
        public int P_id { get; set; }
        public string P_name { get; set; }
        public string P_price { get; set; }

        public string Ex_type { get; set; }
        public string Ex_date { get; set; }
        public string Ex_amount { get; set; }

    }
}
