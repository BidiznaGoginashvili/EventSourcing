using System;

namespace EventSourcing.Shared
{
    public class DomainEvent
    {
        public int AggregateRootId { get; set; }

        public DateTime OccuredOn { get; protected set; }

        public DomainEvent()
        {

        }

        public DomainEvent(int aggregateRootId, DateTime occuredOn)
        {
            AggregateRootId = aggregateRootId;
            OccuredOn = occuredOn;
        }
    }
}
