using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.ViewModel;

namespace MovieRentalCompany.Controllers
{
    [ApiController]
    [Route("Movie")]
    public class MovieController : ControllerBase
    {

        private readonly IMovieServices _services;

        public MovieController(IMovieServices services)
        {
            _services = services;
        }

        [HttpPost]
        public IActionResult RegisterMovie(NewMovie model)
        {
            var movie = _services.RegisterMovie(model.Name, model.Category);

            return Ok(movie);
        }
    }
}
