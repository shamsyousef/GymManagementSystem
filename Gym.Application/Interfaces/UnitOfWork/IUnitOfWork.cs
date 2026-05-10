using Gym.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using Gym.Domain.Entities;

namespace Gym.Application.Interfaces.UnitOfWork
{
   public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Member>Members { get; }
        IGenericRepository<Trainer> Trainers { get; }
        IGenericRepository<MembershipPlan> MembershipPlans { get; }
        IGenericRepository<Session> Sessions { get; }
        IGenericRepository<Booking> Bookings { get; }
        Task<int> SaveChangesAsync(CancellationToken ct);
    }
}
