using Gym.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Domain.Entities
{
    public class Trainer : BaseEntity
    {
        public string fullName { get; private set; }
        public string Specialty { get; private set; }
        
        private Trainer() { }
        public Trainer(string fullName, string specialty)
            => (this.fullName, Specialty) = (fullName, specialty);
        private readonly List<Session> _sessions = new();
        public IReadOnlyCollection<Session> Sessions => _sessions.AsReadOnly();
    }

}
