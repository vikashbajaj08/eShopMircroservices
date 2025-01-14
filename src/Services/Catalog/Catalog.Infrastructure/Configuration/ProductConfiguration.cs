﻿using Catalog.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Infrastructure.Configuration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p=>p.Description).IsRequired();
            builder.Property(p=>p.UnitPrice).HasColumnType("decimal(18,2)");

            builder.HasOne(c=>c.Category).WithMany(p=>p.Products).HasForeignKey(p=>p.CategoryId);
        }
    }
}
