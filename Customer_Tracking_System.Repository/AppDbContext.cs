using Customer_Tracking_System.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        DbSet<Customer> Customers { get; set; }
        DbSet<CustomerInterests> CustomerInterests { get; set; }
        DbSet<Order> Order { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductComment> ProductComments { get; set; }
        DbSet<Seller> Sellers { get; set; }
        DbSet<UserData> UserDatas { get; set; }
    }
}
