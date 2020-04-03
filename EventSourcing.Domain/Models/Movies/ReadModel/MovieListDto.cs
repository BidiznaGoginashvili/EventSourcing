using System;
using EventSourcing.Shared;
using System.Collections.Generic;

namespace EventSourcing.Domain.Models.Movies.ReadModel
{
    public class MovieListDto : BoundedContext
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public string Genres { get; set; }

        public ICollection<MovieListActorDto> MovieActor { get; set; }

        public MovieListDirectorDto MovieDirector { get; set; }

        public MovieListDto(string title, DateTime releaseDate, string description, string imagePath)
        {
            Id = Guid.NewGuid();
            Title = title;
            ReleaseDate = releaseDate;
            Description = description;
            ImagePath = imagePath;
        }
    }

    public class MovieListActorDto
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string FullName { get; set; }

        public MovieListDto MovieListDto { get; set; }

        public MovieListActorDto(string imagePath, string fullName)
        {
            Id = Guid.NewGuid();
            ImagePath = imagePath;
            FullName = fullName;
        }
    }

    public class MovieListDirectorDto
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string FullName { get; set; }

        public int MovieListDtoId { get; set; }
        public MovieListDto MovieListDto { get; set; }

        public MovieListDirectorDto(string imagePath, string fullName)
        {
            Id = Guid.NewGuid();
            ImagePath = imagePath;
            FullName = fullName;
        }
    }
}
