using BackEndBase.Domain.Events;
using System;

namespace BackEndBase.Domain.Commands.Base
{
    public abstract class Command : Message
    {
        public bool ShouldCommit { get; set; }
        public DateTime Timestamp { get; private set; }

        protected Command(bool shouldCommit = true)
        {
            ShouldCommit = shouldCommit;
            Timestamp = DateTime.Now;
        }
    }
}