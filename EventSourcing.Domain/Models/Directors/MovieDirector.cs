namespace EventSourcing.Domain.Models.Directors
{
    public class MovieDirector
    {
        public int MovieId { get; private set; }

        public Movies.Movie Movie { get; private set; }

        public int DirectorId { get; private set; }

        public Director Director { get; private set; }
    }
}
