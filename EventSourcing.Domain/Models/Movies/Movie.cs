using EventSourcing.Domain.Core;
using EventSourcing.Domain.Events.Movies;
using EventSourcing.Domain.Models.Actors;
using EventSourcing.Domain.Models.Directors;
using EventSourcing.Domain.Models.Genres;
using System;
using System.Collections.Generic;

namespace EventSourcing.Domain.Models.Movies
{
    public class Movie : AggregateRoot
    {
        public string Title { get; private set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Budget { get; private set; }
        public decimal Salary { get; private set; }
        public string Description { get; private set; }

        public ICollection<MovieGenre> MovieGenres { get; set; }
        public ICollection<MovieActor> MovieActors { get; set; }
        public ICollection<MovieDirector> MovieDirectors { get; set; }

        public Movie(string title, DateTime releaseDate, decimal budget, decimal salary, string description)
        {
            Id = Guid.NewGuid();
            Title = title;
            ReleaseDate = releaseDate;
            Budget = budget;
            Salary = salary;
            Description = description;

            HandleEvent(new MovieCreated(Id, Title));
        }

        public void ApplyEvent(MovieCreated @event) 
        {
            Id = @event.AggregateRootId;
            Title = @event.Title;
        }
    }
}
