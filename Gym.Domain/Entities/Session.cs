using Gym.Domain.Common;
using Gym.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Domain.Entities
{
    public  class Session : BaseEntity
    {
        public string Title { get; private set; }
        public DateOnly Date { get; private set; }
        public TimeOnly StartTime { get; private set; }
        public int Capacity { get; private set; }
        public SessionStatus Status { get; private set; }
        public int TrainerId { get; private set; }
        public Trainer Trainer { get; private set; }
        public int MemberId { get; private set; }
        public Member Member { get; private set; }
        private readonly List<Booking> _bookings = new();
        public IReadOnlyCollection<Booking> Bookings =>Bookings;
        private Session() { }
        public Session(string title, DateOnly date, TimeOnly startTime, int capacity, int trainerId)
            => (Title, Date, StartTime, Capacity, Status, TrainerId) = (title, date, startTime, capacity, SessionStatus.open, trainerId);
        public void MakeAsFull()
        {
            Status = SessionStatus.Full;
            SetUpdatedAt();
        }
    }
}
