﻿using Customer_Tracking_System.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.DTOs
{
    public class CustomerWithProductCommentDto
    {
        public List<ProductCommentDto> Comment { get; set; }
    }
}
