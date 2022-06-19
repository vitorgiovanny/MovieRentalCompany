using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Controllers;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MovieRentalCompany.Test
{
    public class MovieControllerTest
    {
        MovieController _controller;
        IMovieServices _services;

        public MovieControllerTest()
        {
            _services = new AddMovieFake();
            _controller = new MovieController(_services);
        }

        [Fact]
        [Trait("Movie","Remover Filme pelo Id")]
        public void Remove_Movie_ReturnsOkResult()
        {
            //Arrange
            int idMovie = 1;

            // Act
            var okResult = _controller.Remover(idMovie);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

        [Fact]
        [Trait("Movie", "Adicionar novo Filme")]
        public void Create_Movie()
        {
            var movieNew = new NewMovie
            {
                Name = "Novo filmes teste",
                Category = "Testes"
            };

            var result = _controller.RegisterMovie(movieNew);

            Assert.IsType<OkObjectResult>(result);
        }

    }
}
