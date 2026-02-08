using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatCore.Entites;

namespace TlabatRepository.Data.Config
{
    internal class productConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(n => n.Name).IsRequired();
            builder.Property(n => n.Price).HasColumnType("decimal(18,2)");

            builder.HasOne(n => n.ProductBrand).WithMany()
                .HasForeignKey(n => n.ProductBrandId);

            builder.HasOne(o => o.ProductType).WithMany()
                .HasForeignKey(o => o.ProductTypeId);
        }
    }
}
