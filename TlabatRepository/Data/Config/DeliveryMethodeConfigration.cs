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
    public class DeliveryMethodeConfigration : IEntityTypeConfiguration<DeliveryMethode>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethode> builder)
        {
            builder.Property(x => x.Cost).HasColumnType("decimal(18,2)");
        }
    }
}
