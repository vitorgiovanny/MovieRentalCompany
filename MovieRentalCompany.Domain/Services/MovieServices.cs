using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Repositories;
using MovieRentalCompany.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Services
{
    public class MovieServices : IMovieServices
    {
        private readonly IMovieRepository _repository;

        public MovieServices(IMovieRepository repository)
        {
            _repository = repository;
        }

        public Movie RegisterMovie(string name, string category)
        {
            return _repository.RegisterMovie(name, category).Result;
        }

        public bool RemoveMovie(int id)
        {
            var movie = _repository.GetById(id).Result;

            movie.IsActive = false;
            movie.IsDeleted = DateTime.UtcNow;
            _repository.Update(movie);
            var save = _repository.Save().Result;

            return save>0 ? true : false;
        }
    }
}
