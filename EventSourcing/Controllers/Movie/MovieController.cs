using EventSourcing.Application.Command.Movie;
using Microsoft.AspNetCore.Mvc;

namespace EventSourcing.Controllers.Movie
{
    public class MovieController : Controller
    {
        public IActionResult InsertMovie(CreateMovieCommand command)
        { 

            return View();
        }
    }
}