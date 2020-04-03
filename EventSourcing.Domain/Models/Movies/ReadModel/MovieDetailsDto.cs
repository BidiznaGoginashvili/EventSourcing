using System;
using EventSourcing.Shared;
using System.Collections.Generic;

namespace EventSourcing.Domain.Models.Movies.ReadModel
{
    public class MovieDetailsDto : BoundedContext
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public decimal Budget { get; set; }
        public decimal Salary { get; set; }
        public string ImagePath { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }

        public string Genres { get; set; }

        public ICollection<MovieDetailsActorDto> MovieActor { get; set; }
        public MovieDetailsDirectorDto MovieDirector { get; set; }

        public MovieDetailsDto(string title, DateTime releaseDate, decimal budget, decimal salary, string description, string imagePath, string genres)
        {
            Id = Guid.NewGuid();
            Title = title;
            ReleaseDate = releaseDate;
            Description = description;
            Budget = budget;
            Salary = salary;
            ImagePath = imagePath;
            Genres = genres;
        }
    }

    public class MovieDetailsActorDto : BoundedContext
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string FullName { get; set; }

        public MovieDetailsDto MovieDetailDto { get; set; }

        public MovieDetailsActorDto(string imagePath, string fullName)
        {
            Id = Guid.NewGuid();
            ImagePath = imagePath;
            FullName = fullName;
        }
    }

    public class MovieDetailsDirectorDto : BoundedContext
    {
        public Guid Id { get; set; }
        public string ImagePath { get; set; }
        public string FullName { get; set; }

        public int MovieDetailDtoId { get; set; }
        public MovieDetailsDto MovieDetailDto { get; set; }

        public MovieDetailsDirectorDto(string imagePath, string fullName)
        {
            Id = Guid.NewGuid();
            ImagePath = imagePath;
            FullName = fullName;
        }
    }
}
