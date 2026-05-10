using Gym.Domain.Common;
using Gym.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Gym.Domain.Entities
{
    public class Member : BaseEntity
    {
        public string? FullName { get; private set; }
        public string? Email { get; private set; }
        public string? Phone { get; private set; }
        public DateOnly MembershipStartDate { get; private set; }
        public DateOnly MembershipEndDate { get; private set; }
        public MembershipStatus Status { get; private set; }
        public int MembershipPlanId { get; private set; }
        public MembershipPlan? MembershipPlan { get; private set; }

        private readonly List<Booking> _bookings = new();
        public IReadOnlyCollection<Booking> Bookings => _bookings.AsReadOnly(); 
        
       
        private Member() { } // for efcore
        public Member(string fullName, string phone, string email, DateOnly startDate, DateOnly endDate, int membershipPlanId)
        => (FullName, Phone, Email, MembershipStartDate, MembershipEndDate, MembershipPlanId, Status)
         = (fullName, phone, email, startDate, endDate, membershipPlanId, MembershipStatus.Active);
        public void ExpireMembership()
        {
            Status = MembershipStatus.Expired;
            SetUpdatedAt();
        }
    }
}
