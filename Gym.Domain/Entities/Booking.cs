using Gym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Domain.Entities
{
    public class Booking : BaseEntity
    {
        public DateTime BookingDate { get; private set; }
        public int MemberId { get; private set; }

        public Member Member { get; private set; }
        public int SessionId { get; private set; }
        public Session Session { get; private set; } = null;
        private Booking() { }
        public Booking(int memberId, int sessionId)
            => (MemberId, SessionId, BookingDate) = (memberId, sessionId, DateTime.UtcNow);
    }
}
