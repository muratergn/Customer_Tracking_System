using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Core.DTOs
{
    public abstract class BaseDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
