﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core
{
    public class ProductComment
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer customer { get; set; }
        public int ProductId { get; set; }
        public Product product { get; set; }
        public string Comment { get; set; }
    }
}
