using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.DTOs
{
    public class CustomerInterestsDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Interest { get; set; }
    }
}
