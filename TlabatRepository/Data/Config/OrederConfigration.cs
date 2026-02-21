using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites.Order_Agreggate;

namespace TlabatRepository.Data.Config
{
    public class OrederConfigration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(x => x.ShippingAddress, x => x.WithOwner());

            builder.Property(x => x.Status).HasConversion(
                x => x.ToString(),
                x => (OrderStatus)Enum.Parse(typeof(OrderStatus), x)
                );
            builder.Property(x => x.Subtotal).HasColumnType("decimal(18,2)");


        }
    }
}
