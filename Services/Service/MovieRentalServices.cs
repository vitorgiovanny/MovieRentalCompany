using MovieRentalCompany.Domain.DTOs;
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
    public class MovieRentalServices : IMovieRentalServices
    {
        private readonly IRepository<MovieRental> _repository;

        public MovieRentalServices(IRepository<MovieRental> repository)
        {
            _repository = repository;
        }

        public MovieRental Register(int id_Customer, int id_Movie)
        {
            /*
            var selectedAvailable = _repository.GetByIdMovie(id_Movie).Result.Select(sm => sm.Devolution == null).ToList();

            if(selectedAvailable != null && selectedAvailable.Any()) return null;

            var previsionReturn = new ReturnMovie(DateTime.UtcNow);

            var movieRental = _repository.Register(id_Customer, id_Movie, previsionReturn.PrevisionDevolution);
            var save = _repository.Save().Result;
            */
            return null;
        }

        public DevolutionDTO Devlotuion(int id)
        {
            
            var MovieRental = _repository.GetById(id);

            /*
            rental.Devolution = DateTime.UtcNow;

            var devolution = new DevolutionDTO();

            if(rental.Devolution>rental.PrevisionDevolution)
            {
                devolution.Late = true;
            }

            _repository.Update(rental);

            var save = _repository.Save().Result;
            */
            return null;
        }

        public bool Canceled(int id)
        {
            var rental = _repository.GetById(id);

            rental.Canceled = DateTime.UtcNow;

            _repository.Update(rental);

            return true;
        }
    }
}
