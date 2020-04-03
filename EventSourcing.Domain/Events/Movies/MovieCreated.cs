using EventSourcing.Shared;
using System;

namespace EventSourcing.Domain.Events.Movies
{
    public class MovieCreated : DomainEvent
    {
        public string Title { get; set; }
     
        public MovieCreated()
        {

        }

        public MovieCreated(Guid movieId, string title)
        {
            AggregateRootId = movieId;
            Title = title;
        }
    }
}
