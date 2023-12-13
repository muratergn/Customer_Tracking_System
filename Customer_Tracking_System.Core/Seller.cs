using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core
{
    public class Seller : User
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string? PhoneNumber { get; set; }
        public int Point { get; set; }
        public int PointNumber { get; set; }
        public int TransactionsNumber { get; set; } = 0;
        public string? ProfilePicture { get; set; }
        public ICollection<Product> Product { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        public ICollection<Order> Order { get; set; }
    }
}
