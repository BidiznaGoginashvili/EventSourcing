using EventSourcing.Domain.Core;
using EventSourcing.Shared;
using System;

namespace EventSourcing.Application.Infrastructure.EventStore
{
    public interface IEventStoreRepository
    {
        void Save(AggregateRoot aggregateRoot);

        void Append(DomainEvent domainEvent);

        T GetById<T>(Guid id, long startPosition = 0) where T : AggregateRoot;
    }
}
