using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product? Products { get; set; }
        public int? CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customers { get; set; }
        public int? SellerId { get; set; }
        [ForeignKey("SellerId")]
        public Seller? Sellers { get; set; }
        public string Reply { get; set; }
    }
}
