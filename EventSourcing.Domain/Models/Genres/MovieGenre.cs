namespace EventSourcing.Domain.Models.Genres
{
    public class MovieGenre
    {
        public int MovieId { get; private set; }

        public Movies.Movie Movie { get; private set; }

        public int GenreId { get; private set; }

        public Genre Genre { get; private set; }
    }
}
