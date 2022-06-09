using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Controllers;
using MovieRentalCompany.Domain.Interfaces.Services;
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
        public void Remove_Movie_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.Remover(1);

            // Assert
            Assert.IsType<OkObjectResult>(okResult);
        }

    }
}
