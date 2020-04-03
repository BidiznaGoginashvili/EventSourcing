using EventSourcing.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace EventSourcing.Domain.Core
{
    public class AggregateRoot : Entity
    {
        private readonly List<DomainEvent> _pendingEvents = new List<DomainEvent>();

        [JsonIgnore]
        public virtual IReadOnlyList<DomainEvent> PendingEvents => _pendingEvents;

        public virtual void HandleEvent(DomainEvent newEvent)
        {
            _pendingEvents.Add(newEvent);
        }

        public virtual void ClearEvents()
        {
            _pendingEvents.Clear();
        }
    }
}
