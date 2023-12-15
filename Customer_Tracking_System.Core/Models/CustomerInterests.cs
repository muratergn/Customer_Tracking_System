using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.Models
{
    public class CustomerInterests
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string Interest { get; set; }
        public Customer Customer { get; set; }

    }
}
