using System;
using System.Collections.Generic;
using System.Text;
using Gym.Application.Interfaces.UnitOfWork;
using Gym.Application.Interfaces.Repositories;
using Gym.Infrastructure.Data;
using Gym.Domain.Entities;
using Gym.Infrastructure.Repositories;


namespace Gym.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GymDbContext _context;
        public IGenericRepository<Member> Members { get;  }
        public IGenericRepository<Trainer> Trainers { get; }
        public IGenericRepository<MembershipPlan> MembershipPlans { get; }
        public IGenericRepository<Session> Sessions { get; }
        public IGenericRepository<Booking> Bookings { get; }
        public UnitOfWork(GymDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            Members = new GenericRepository<Member>(_context);
            Trainers = new GenericRepository<Trainer>(_context);
            MembershipPlans = new GenericRepository<MembershipPlan>(_context);
            Sessions = new GenericRepository<Session>(_context);
            Bookings = new GenericRepository<Booking>(_context);
        }
        public Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return _context.SaveChangesAsync(ct);
        }

        public void Dispose()
            {
                _context.Dispose();
        }

    }
}
