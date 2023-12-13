using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core
{
    public class Customer : User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public int TransactionsNumber { get; set; } = 0;
        public string? ProfilePicture { get; set; }
        public ICollection<CustomerInterests> Interest { get; set;}
        public ICollection<ProductComment> ProductComments { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
