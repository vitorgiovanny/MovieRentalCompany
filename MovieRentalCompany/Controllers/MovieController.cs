using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Constante.Menssagen.Business;
using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace MovieRentalCompany.Controllers
{
    [ApiController]
    [Route("Movie")]
    public class MovieController : VideoRentalStoreGenericController<Movie,IServices<Movie>>
    {
        private readonly IServices<Movie> _services;
        private readonly IServices<MovieRental> _servicesRentalStoreMovie;
        public MovieController(IServices<Movie> services, IServices<MovieRental> storeMovie) : base(services)
        { 
            _services = services; 
            _servicesRentalStoreMovie = storeMovie;
        }

        /// <summary>
        /// Adicionar novo filme
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegisterMovie(NewMovie model)
        {
            try
            {
                _services.Add(new Movie
                {
                    Category = model.Category,
                    Name = model.Name,
                    IsActive = true
                });

                return Ok(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Success,
                    Code = CodesMenssage.MovieAddSuccess,
                    Description = "Filme registrado com sucesso.",
                    Parameters = new Movie { Name = model.Name, Category = model.Category }
                });
            }catch (Exception ex)
            {
                return Ok(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Error,
                    Code = CodesMenssage.MovieErro,
                    Description = $"Houve um erro durante a tentativa de salvar o novo filme./n detalhe: {ex.Message}",
                    Parameters = new Movie {  }
                });
            }
        }

        /// <summary>
        /// Remover filme
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("remove")]
        public IActionResult Remover(int id)
        {
            var movie = _services.GetById(id);
            var storeMovieRentals = _servicesRentalStoreMovie.GetAll(filme => filme.Id_Movie == id).ToList()
                .OfType<MovieRental>()
                .ToList();

            if (movie is null) return BadRequest(new ResponseMessageJson
            {
                Type = ResponseMessageJson.Error,
                Code = CodesMenssage.MovieRemovedError,
                Description = "Esse filme nao existe"
            });

            if (movie.IsDeleted.HasValue || storeMovieRentals.Any(t => t.Devolution == null))
                return BadRequest(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Error,
                    Code = CodesMenssage.MovieRemovedError,
                    Description = $"Esse filme ja foi {(movie.IsDeleted.HasValue ? "deletado" : "alugado")}"
                });

            _services.Remove(id);

            return Ok(new ResponseMessageJson
             {
                    Type = ResponseMessageJson.Success,
                    Code = CodesMenssage.MovieRemovedSuccess,
                    Description = "Filme removido com sucesso."
            });
        }
    }
}
