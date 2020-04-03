using EventSourcing.Application.Infrastructure.EventStore;
using EventSourcing.Application.Infrastructure.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventSourcing.Application.Query.Movie
{
    public class MovieQueryHandler : IRequestHandler<MovieDetailsQuery, MovieDetailsQueryResult>
    {
        protected IEventStoreRepository _eventStoreRepository = new EventStoreRepository();

        public Task<MovieDetailsQueryResult> Handle(MovieDetailsQuery request)
        {
            try
            {
                var movie = _eventStoreRepository.GetById<Domain.Models.Movies.ReadModel.MovieDetailsDto>(request.Id);

                var details = new MovieDetailsQueryResult();

                details.Title = movie.Title;
                details.Salary = movie.Salary;
                details.Genres = movie.Genres;
                details.Budget = movie.Budget;
                details.ImagePath = movie.ImagePath;
                details.ReleaseDate = movie.ReleaseDate;
                details.Description = movie.Description;
                details.MovieDirector = new MovieDetailsDirectorResult()
                {
                    FullName = movie.MovieDirector.FullName,
                    ImagePath = movie.MovieDirector.ImagePath
                };
                details.MovieActor = movie.MovieActor.Select(mact => new MovieDetailsActorResult
                {
                    FullName = mact.FullName,
                    ImagePath = mact.ImagePath
                }).ToList();

                return Task.FromResult(details);
            }
            catch (Exception exception)
            {
                return Task.FromResult(default(MovieDetailsQueryResult));
            }
        }
    }
}
