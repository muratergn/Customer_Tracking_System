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
    internal class CustomerInterestsConfiguration : IEntityTypeConfiguration<CustomerInterests>
    {
        public void Configure(EntityTypeBuilder<CustomerInterests> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Interest).IsRequired().HasMaxLength(70);

            builder.HasOne(x => x.Customer).WithMany(x => x.Interest).HasForeignKey(x => x.CustomerId);
        }
    }
}
