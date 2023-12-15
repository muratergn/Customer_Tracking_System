using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Interests { get; set; }
        public int Stock { get; set; }
        public string? ProductPicture { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
        public ICollection<ProductComment> ProductComments { get; set; }
        public ICollection<Order> Order { get; set; }

    }
}
