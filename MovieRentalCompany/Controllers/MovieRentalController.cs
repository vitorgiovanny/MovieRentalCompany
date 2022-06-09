using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.ViewModel;

namespace MovieRentalCompany.Controllers
{
    [ApiController]
    [Route("RentMovie")]
    public class MovieRentalController : ControllerBase
    {

        private readonly IMovieRentalServices _services;

        public MovieRentalController(IMovieRentalServices services)
        {
            _services = services;
        }

        [HttpPost]
        public IActionResult Rental(int idCustom, int idMovie)
        {
            var rental = _services.Register(idCustom, idMovie);

            var response = new MovieRentalViewModel
            {
                ReturnMovie = rental.PrevisionDevolution
            };

            return Ok(response);
        }

        [HttpPost]
        [Route("devolution")]
        public IActionResult Devolution(int id)
        {
            _services.Update(id);

            return Ok();
        }
    }
}
