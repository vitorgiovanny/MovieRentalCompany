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
        private readonly IRepository<Movie> _repository;

        public MovieServices(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        public Movie RegisterMovie(string name, string category)
        {
            _repository.Add(new Movie { Name = name, Category = category });

            return null;
        }

        public bool RemoveMovie(int id)
        {
            //var searchmovie = _repositoryMovieRental
              //  .GetByIdMovie(id).Result.Select(p => p.Devolution == null).ToList();

            

            //var movie = _repository.GetById(id).Result;

            //movie.IsActive = false;
            //movie.IsDeleted = DateTime.UtcNow;
            //_repository.Update(movie);
            //var save = _repository.Save().Result;
            return false;
            //return save>0 ? true : false;
        }
    }
}
