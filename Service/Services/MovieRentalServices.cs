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

        public bool Canceled(int id)
        {
            var rental = _repository.GetById(id);

            rental.Canceled = DateTime.UtcNow;

            _repository.Update(rental);

            return true;
        }

        public void Add(object entity)
            => _repository.Add((MovieRental)entity);

        public void Remove(int id)
        {
            var movieStore = this.GetById(id);

            if (movieStore != null)
            {
                movieStore.Canceled = DateTime.UtcNow;
                _repository.Update(movieStore);
            }
        }

        public List<object> GetAll(Expression<Func<MovieRental, bool>> condition)
        {
            if (condition == null) return (List<object>)_repository.GetAll();
            return (List<object>)_repository.GetByCondition(condition);
        }

        public MovieRental GetById(int id)
            => _repository.GetById(id);

        public void Update(MovieRental entity)
            => _repository.Update(entity);
    }
}