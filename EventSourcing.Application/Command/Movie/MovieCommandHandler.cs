using System.Threading.Tasks;
using EventSourcing.Infrastructure.Repository;
using EventSourcing.Application.Infrastructure.Mediator;
using System.Collections.Generic;

namespace EventSourcing.Application.Command.Movie
{
    public class MovieCommandHandler : IRequestHandler<CreateMovieCommand, bool>
    {
        protected IRepository<Domain.Models.Movies.Movie> _movieRepository = new Repository<Domain.Models.Movies.Movie>();
        protected IRepository<Domain.Models.Movies.ReadModel.MovieDetailsDto> _movieDetailsRepository = new Repository<Domain.Models.Movies.ReadModel.MovieDetailsDto>();
        protected IRepository<Domain.Models.Movies.ReadModel.MovieListDto> _movieListRepository = new Repository<Domain.Models.Movies.ReadModel.MovieListDto>();

        public Task<bool> Handle(CreateMovieCommand request)
        {
            var movie = new Domain.Models.Movies.Movie(request.Title, request.ReleaseDate, request.Budget, request.Salary, request.Description);
            var movieDetails = new Domain.Models.Movies.ReadModel.MovieDetailsDto(request.Title, request.ReleaseDate, request.Budget, request.Salary, request.Description, request.ImagePath, request.Genres.ToString());
            var movieList = new Domain.Models.Movies.ReadModel.MovieListDto(request.Title, request.ReleaseDate, request.Description, request.ImagePath);

            Parallel.Invoke(
            () =>
            {
                _movieRepository.Insert(movie);
            },
            () =>
            {
                _movieDetailsRepository.Insert(movieDetails);
            },
            () =>
            {
                _movieListRepository.Insert(movieList);
            });


        }
    }
}
