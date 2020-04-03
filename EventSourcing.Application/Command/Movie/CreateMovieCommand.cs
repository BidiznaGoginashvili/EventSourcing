using System;
using System.Collections.Generic;

namespace EventSourcing.Application.Command.Movie
{
    public class CreateMovieCommand
    {
        public string Title { get; set; }

        public decimal Budget { get; set; }

        public decimal Salary { get; set; }

        public string ImagePath { get; set; }

        public string Description { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int DirectorId { get; set; }

        public IList<int> Genres { get; set; }

        public IList<int> ActorIds { get; set; }
    }
}
