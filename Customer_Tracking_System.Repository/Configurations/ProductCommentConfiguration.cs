using Customer_Tracking_System.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Tracking_System.Repository.Configurations
{
    public class ProductCommentConfiguration : IEntityTypeConfiguration<ProductComment>
    {
        public void Configure(EntityTypeBuilder<ProductComment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Comment).IsRequired().HasMaxLength(300);

            builder.HasOne(x => x.customer).WithMany(x => x.ProductComments).HasForeignKey(x => x.CustomerId);
            builder.HasOne(x => x.product).WithMany(x => x.ProductComments).HasForeignKey(x => x.ProductId);
        }
    }
}
