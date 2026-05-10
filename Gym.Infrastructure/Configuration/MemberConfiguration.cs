using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
           builder.ToTable("Members");
              builder.HasKey(m => m.Id);
              builder.Property(m => m.FullName)
                .IsRequired()
                .HasMaxLength(100);
                builder.Property(m => m.Phone).IsRequired().HasMaxLength(15);
              builder.Property(m => m.Email).IsRequired().HasMaxLength(100);
            builder.Property(m => m.MembershipStartDate).HasColumnType("date");
            builder.Property(m => m.MembershipEndDate).HasColumnType("date");
            builder.Property(m => m.Status)
              .IsRequired();

            builder.HasOne(m => m.MembershipPlan)
              .WithMany()
              .HasForeignKey(m => m.MembershipPlanId);
                
            builder.HasMany(m => m.Bookings)
              .WithOne(b => b.Member)
              .HasForeignKey(b => b.MemberId);


        }
    }
}
