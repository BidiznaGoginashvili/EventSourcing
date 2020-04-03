using System;
using EventSourcing.Domain.Core;
using System.Collections.Generic;

namespace EventSourcing.Domain.Models.Genres
{
    public class Genre : AggregateRoot
    {
        public string Title { get; private set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }

        public Genre(int id, string title)
        {
            Id = Guid.NewGuid;
            Title = title;
        }
    }
}
