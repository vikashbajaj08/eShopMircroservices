using Authentication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication.Infrastructure.Data.Configuration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Name).IsRequired();
            builder.Property(p=>p.Email).IsRequired();
            builder.Property(p=>p.Password).IsRequired();
            builder.Property(p=>p.PhoneNumber).IsRequired();

            builder.HasMany(r=>r.Roles).WithMany(u=>u.Users)
                .UsingEntity<Dictionary<string,object>>("UserRole",
                r=>r.HasOne<Role>().WithMany().HasForeignKey("RoleId"),
                u=>u.HasOne<User>().WithMany().HasForeignKey("UserId"),
                ru =>
                {
                    ru.HasKey("UserId","RoleId");
                    ru.ToTable("UserRoles");
                });
        }
    }
}
