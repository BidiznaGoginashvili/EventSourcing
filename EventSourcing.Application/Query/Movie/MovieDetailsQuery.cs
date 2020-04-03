using System;
using System.Collections.Generic;
using System.Text;

namespace EventSourcing.Application.Query.Movie
{
    public class MovieDetailsQuery
    {
        public Guid Id { get; set; }
    }
    public class MovieDetailsQueryResult
    {
        public string Title { get; set; }

        public decimal Budget { get; set; }

        public decimal Salary { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Genres { get; set; }

        public IList<MovieDetailsActorResult> MovieActor { get; set; }

        public MovieDetailsDirectorResult MovieDirector { get; set; }
    }

    public class MovieDetailsActorResult
    {
        public string ImagePath { get; set; }
        public string FullName { get; set; }
    }

    public class MovieDetailsDirectorResult
    {
        public string ImagePath { get; set; }
        public string FullName { get; set; }
    }
}
