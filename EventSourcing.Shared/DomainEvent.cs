using System;

namespace EventSourcing.Shared
{
    public class DomainEvent
    {
        public Guid AggregateRootId { get; set; }

        public DateTime OccuredOn { get; protected set; }

        public DomainEvent()
        {

        }

        public DomainEvent(Guid aggregateRootId, DateTime occuredOn)
        {
            AggregateRootId = aggregateRootId;
            OccuredOn = occuredOn;
        }
    }
}
