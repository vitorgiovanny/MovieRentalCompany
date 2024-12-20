﻿using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Constante.Menssagen.Business;
using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Entities.ComplexType;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.ViewModel;

namespace MovieRentalCompany.Controllers
{
    [ApiController]
    [Route("RentMovie")]
    public class MovieRentalController : VideoRentalStoreGenericController<MovieRental, IServices<MovieRental>>
    {

        private readonly IServices<MovieRental> _services;
        private readonly IServices<Movie> _servicesMovie;

        public MovieRentalController(IServices<MovieRental> services, IServices<Movie> servicesOne) : base(services) 
        {
            _services = services;
            _servicesMovie = servicesOne;
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
                    Code = CodesMenssage.MovieIsAlreadyRented,
                    Description = "O Filme já está Locado"
                });
            }

            if (_servicesMovie.GetById(idMovie)?.IsDeleted != null)
            {
                return BadRequest(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Error,
                    Code = CodesMenssage.MovieIsAlreadyRented,
                    Description = "O Filme já está removido"
                });
            }

            var movieRentalStore = new MovieRental { Id_Customer = idCustom, Id_Movie = idMovie, Creater = DateTime.UtcNow, PrevisionDevolution = new ReturnMovie(DateTime.UtcNow).PrevisionDevolution };

            _services.Add(movieRentalStore);

            return Ok(new ResponseMessageJson
            {
                Type = ResponseMessageJson.Success,
                Code = CodesMenssage.MovieRented,
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
            var movieStore = _services.GetById(id);

            movieStore.Devolution = DateTime.UtcNow;
            _services.Update(movieStore);

            return Ok(new ResponseMessageJson
            {
                Type = ResponseMessageJson.Success,
                Code = CodesMenssage.MovieDevolutionSuccess,
                Description = movieStore.PrevisionDevolution < movieStore.Devolution ? "Obrigado, volte sempre." : "Filme Alocado Atrasado, sera gerado Multa"
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
            _services.Remove(id);

           return Ok(new ResponseMessageJson
           {
                Type = ResponseMessageJson.Success,
                Code = CodesMenssage.MovieRentalCanceledSuccess,
                Description = "Filme cancelado"
            });
        }
    }
}
