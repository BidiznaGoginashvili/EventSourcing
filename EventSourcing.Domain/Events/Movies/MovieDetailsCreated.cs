using EventSourcing.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Domain.Events.Movies
{
    public class MovieDetailsCreated : DomainEvent
    {
        public string Title { get; set; }

        public MovieDetailsCreated()
        {

        }

        public MovieDetailsCreated(Guid movieId, string title)
        {
            AggregateRootId = movieId;
            Title = title;
        }
    }
}
