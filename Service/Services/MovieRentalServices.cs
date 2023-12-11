using MovieRentalCompany.Domain.DTOs;
using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Repositories;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.Infrastructure.Repositories;
using System;
using System.Linq.Expressions;

namespace MovieRentalCompany.Domain.Services
{
    public class MovieRentalServices : IServices<MovieRental>
    {
        private readonly IRepository<MovieRental> _repository;

        public MovieRentalServices(IRepository<MovieRental> repository)
        {
            _repository = repository;
        }

        public MovieRental Register(int id_Customer, int id_Movie)
        {
  
            return null;
        }

        public DevolutionDTO Devlotuion(int id)
        {

            return null;
        }

        public bool Canceled(int id)
        {
            var rental = _repository.GetById(id);

            rental.Canceled = DateTime.UtcNow;

            _repository.Update(rental);

            return true;
        }

        public void Add(object entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public List<object> GetAll(Expression<Func<MovieRental, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public MovieRental GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}