using System;
using System.Collections.Generic;
using System.Text;
using Gym.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Configuration
{
    public class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable("Sessions");
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Date)
                .IsRequired()
                .HasColumnType("date");
            builder.Property(s => s.StartTime)
                .IsRequired()
                .HasColumnType("time");
            
            builder.Property(s => s.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(s => s.Capacity).IsRequired();
            builder.Property(s => s.Status)
                .IsRequired();
            builder.HasOne(s => s.Trainer)
                .WithMany(t => t.Sessions)
                .HasForeignKey(s => s.TrainerId);
            builder.HasMany(s=>s.Bookings)
                .WithOne(b=>b.Session)
                .HasForeignKey(b=>b.SessionId);


        }
    }
}
