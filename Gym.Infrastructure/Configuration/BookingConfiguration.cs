using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.Infrastructure.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.BookingDate)
                .IsRequired()
                .HasColumnType("date");
            builder.HasIndex(b => new { b.MemberId, b.SessionId })
                .IsUnique();/// Ensures a member can book a session only once
            builder.HasOne(b => b.Member)
                .WithMany(m => m.Bookings)
                .HasForeignKey(b => b.MemberId)
                .OnDelete(DeleteBehavior.NoAction); 

            builder.HasOne(b => b.Session)
                .WithMany(s => s.Bookings)
                .HasForeignKey(b => b.SessionId)
                .OnDelete(DeleteBehavior.NoAction);







        }
    }
}
