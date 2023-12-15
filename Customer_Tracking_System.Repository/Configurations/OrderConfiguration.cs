using Customer_Tracking_System.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Repository.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Reply).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.Products).WithMany(x => x.Order).HasForeignKey(x => x.ProductId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Customers).WithMany(x => x.Order).HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.Sellers).WithMany(x => x.Order).HasForeignKey(x => x.SellerId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
