using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.Domain.Models;
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

            return Ok(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Success,
                    Code = ResponseCodes.MovieAddSuccess,
                    Description = "Filme registrado com sucesso.",
                    Parameters = movie
                });
        }
        
        [HttpPost]
        [Route("remove")]
        public IActionResult Remover(int id)
        {
            var status = _services.RemoveMovie(id);

            if(status == true)
            {
                return Ok(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Success,
                    Code = ResponseCodes.MovieRemovedSuccess,
                    Description = "Filme removido com sucesso."
                });
            }

            return BadRequest(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Error,
                    Code = ResponseCodes.MovieRemovedError,
                    Description = "Esse filme está alugado, aguarde o retorno para remover."
                });
        }
    }
}
