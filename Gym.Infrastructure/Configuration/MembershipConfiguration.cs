using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Configuration
{
    public class MembershipConfiguration : IEntityTypeConfiguration<MembershipPlan>
    {
        public void Configure(EntityTypeBuilder<MembershipPlan> builder)
        {
            builder.ToTable("MembershipPlans");
            builder.HasKey(mp => mp.Id);
            builder.Property(mp => mp.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(mp => mp.Price).HasColumnType("decimal(10, 2)");
            builder.Property(mp => mp.MaxSessionsPerMonth).IsRequired();
            builder.HasMany<Member>()          
              .WithOne(m => m.MembershipPlan)
              .HasForeignKey(m => m.MembershipPlanId);
        }

    }
}
