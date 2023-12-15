using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.DTOs
{
    public class CustomerUpdateDto
    {
        public string? PhoneNumber { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string? ProfilePicture { get; set; }
    }
}
