using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Domain.Entities;

namespace Gym.Infrastructure.Data
{
    public class GymDbContext : DbContext
    {
        public GymDbContext(DbContextOptions<GymDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(GymDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MembershipPlan> MembershipPlans { get; set; }
    }
    }
