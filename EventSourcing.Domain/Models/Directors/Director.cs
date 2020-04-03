using System;
using EventSourcing.Domain.Core;
using System.Collections.Generic;

namespace EventSourcing.Domain.Models.Directors
{
    public class Director : AggregateRoot
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public ICollection<MovieDirector> MovieDirectors { get; set; }

        public Director(int id, string lastName, string firstName)
        {
            Id = Guid.NewGuid();
            LastName = lastName;
            FirstName = firstName;
        }
    }
}
