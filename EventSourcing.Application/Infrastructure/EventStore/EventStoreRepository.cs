using EventSourcing.Domain.Core;
using EventSourcing.Shared;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EventSourcing.Application.Infrastructure.EventStore
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly string _streamPrefix = "movies_";

        private JsonSerializerSettings _jsonSettings = new JsonSerializerSettings();

        private static IEventStoreConnection CreateConnection()
        {
            var connection = EventStoreConnection.Create(new IPEndPoint(IPAddress.Loopback, 1113));
            connection.ConnectAsync().Wait();
            return connection;
        }

        public void Append(DomainEvent domainEvent)
        {
            var connection = CreateConnection();
            var streamName = $"{_streamPrefix}{domainEvent.AggregateRootId}";

            var eventId = Guid.NewGuid();
            var eventType = domainEvent.GetType().Name;
            var isJson = true;
            var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(domainEvent, _jsonSettings));
            var metadata = Encoding.UTF8.GetBytes(domainEvent.AggregateRootId.ToString());
            var eventData = new EventData(eventId, eventType, isJson, data, metadata);

            connection.AppendToStreamAsync(streamName, ExpectedVersion.Any, eventData).Wait();
        }

        public T GetById<T>(Guid id, long startPosition = 0) where T : AggregateRoot
        {
            var connection = CreateConnection();

            var streamName = $"{_streamPrefix}{id}";
            var streamEvents = new List<ResolvedEvent>();

            StreamEventsSlice currentSlice;
            do
            {
                currentSlice = connection.ReadStreamEventsForwardAsync(streamName, startPosition, 100, false).Result;
                startPosition = currentSlice.NextEventNumber;

                streamEvents.AddRange(currentSlice.Events);
            } while (!currentSlice.IsEndOfStream);

            dynamic aggregate = Activator.CreateInstance<T>();

            foreach (var evt in streamEvents)
            {
                dynamic domainEvent = JsonConvert.DeserializeObject(Encoding.UTF8.GetString(evt.Event.Data), _jsonSettings);
                aggregate.ApplyEvent(domainEvent);
            }

            return aggregate;
        }

        public void Save(AggregateRoot aggregateRoot)
        {
            foreach (var domainEvent in aggregateRoot.PendingEvents)
            {
                Append(domainEvent);
            }
        }
    }
}
