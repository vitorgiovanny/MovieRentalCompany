using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Entities.ComplexType;
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
        private readonly IMovieRentalRepository _repository;

        public MovieRentalServices(IMovieRentalRepository repository)
        {
            _repository = repository;
        }

        public MovieRental Register(int id_Customer, int id_Movie)
        {

            var selectedAvailable = _repository.GetByIdMovie(id_Movie).Result.Select(sm => sm.Devolution == null).ToList();

            if(selectedAvailable != null && selectedAvailable.Any()) return null;

            var previsionReturn = new ReturnMovie(DateTime.UtcNow);

            var movieRental = _repository.Register(id_Customer, id_Movie, previsionReturn.PrevisionDevolution);
            var save = _repository.Save().Result;

            return movieRental.Result;
        }

        public void Update(int id)
        {
            var rental = _repository.GetById(id).Result;

            rental.Devolution = DateTime.UtcNow;

            _repository.Update(rental);
            var save = _repository.Save().Result;
        }
    }
}
