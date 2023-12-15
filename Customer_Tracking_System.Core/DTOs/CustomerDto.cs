using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.DTOs
{
    public class CustomerDto : BaseDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public int TransactionsNumber { get; set; } = 0;
        public string? ProfilePicture { get; set; }
    }
}
