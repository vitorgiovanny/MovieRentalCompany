using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.Domain.Models;
using MovieRentalCompany.ViewModel;

namespace MovieRentalCompany.Controllers
{
    [ApiController]
    [Route("Movie")]
    public class MovieController : VideoRentalStoreGenericController<Movie,IServices<Movie>>
    {
        private readonly IServices<Movie> _services;

        public MovieController(IServices<Movie> services) : base(services)
        { _services = services; }

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
                    Code = ResponseCodes.MovieAddSuccess,
                    Description = "Filme registrado com sucesso.",
                    Parameters = new Movie { Name = model.Name, Category = model.Category }
                });
            }catch (Exception ex)
            {
                return Ok(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Error,
                    Code = ResponseCodes.MovieErro,
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

            if(movie is null) return BadRequest(new ResponseMessageJson
            {
                Type = ResponseMessageJson.Error,
                Code = ResponseCodes.MovieRemovedError,
                Description = "Esse filme nao existe"
            });

            if (movie.IsDeleted.HasValue || movie.MovieRentals.Any(t => t.Devolution == null)) 
                return BadRequest(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Error,
                    Code = ResponseCodes.MovieRemovedError,
                    Description = "Esse filme ja foi deletado ou alugado"
                });

            _services.Remove(id);

            return Ok(new ResponseMessageJson
             {
                    Type = ResponseMessageJson.Success,
                    Code = ResponseCodes.MovieRemovedSuccess,
                    Description = "Filme removido com sucesso."
            });
        }
    }
}
