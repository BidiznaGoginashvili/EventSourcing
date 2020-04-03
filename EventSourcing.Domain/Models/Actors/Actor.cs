using EventSourcing.Domain.Core;
using System;
using System.Collections.Generic;

namespace EventSourcing.Domain.Models.Actors
{
    public class Actor : AggregateRoot
    {
        public string LastName { get; private set; }
        public string FirstName { get; private set; }
        public ICollection<MovieActor> MovieActors { get; set; }

        public Actor(string lastName, string firstName)
        {
            Id = Guid.NewGuid();
            LastName = lastName;
            FirstName = firstName;
        }
    }
}
