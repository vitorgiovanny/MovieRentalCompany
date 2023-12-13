using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.Domain.Models;
using MovieRentalCompany.ViewModel;

namespace MovieRentalCompany.Controllers
{
    [ApiController]
    [Route("RentMovie")]
    public class MovieRentalController : VideoRentalStoreGenericController<MovieRental, IServices<MovieRental>>
    {

        private readonly IServices<MovieRental> _services;

        public MovieRentalController(IServices<MovieRental> services) : base(services) 
        {
            _services = services;
        }

        /// <summary>
        /// Locar Filme
        /// </summary>
        /// <param name="idCustom"></param>
        /// <param name="idMovie"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Rental(int idCustom, int idMovie)
        {
            
            if(idCustom==0 && idMovie==0)
            {
                return BadRequest(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Error,
                    Code = ResponseCodes.MovieIsAlreadyRented,
                    Description = "O Filme já está Locado"
                });
            }

            var movieRentalStore = new MovieRental { Id_Customer = idCustom, Id_Movie = idMovie };

            _services.Add(movieRentalStore);

            return Ok(new ResponseMessageJson
            {
                Type = ResponseMessageJson.Success,
                Code = ResponseCodes.MovieRented,
                Description = "O Filme Locado",
                Parameters = new MovieRentalViewModel
                {
                    ReturnMovie = movieRentalStore.PrevisionDevolution
                }
            });
        }

        /// <summary>
        /// Devolver Filme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("devolution")]
        public IActionResult Devolution(int id)
        {
            var dto = _services.Devlotuion(id);

            if(dto.Late == true)
            {
                return Ok(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Success,
                    Code = ResponseCodes.MovieLate,
                    Description = "O Filme está Atrasado, pode haver multas"
                });
            }

            return Ok(new ResponseMessageJson
            {
                Type = ResponseMessageJson.Success,
                Code = ResponseCodes.MovieDevolutionSuccess,
                Description = "Obrigado, volte sempre."
            });
        }

        /// <summary>
        /// Cancelar Locação
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("canceled")]
        public IActionResult CanceledRental(int id)
        {
            var canceled = _services.Canceled(id);

            if(canceled)
            {
                return Ok(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Success,
                    Code = ResponseCodes.MovieRentalCanceledSuccess,
                    Description = "Filme cancelado"
                });
            }

            return BadRequest(new ResponseMessageJson
            {
                Type = ResponseMessageJson.Error,
                Code = ResponseCodes.MovieRentalCanceledError,
                Description = "Houve ume erro, entre em contato com support"
            });
        }
    }
}
