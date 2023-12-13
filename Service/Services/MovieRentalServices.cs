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
            if (condition == null) return new List<object>() { _repository.GetAll() };

            var result = _repository.GetByCondition(condition)
                .Select(c => new { c });

            return result.Count() > 0 ? new List<object>() { result } : null;
        }

        public MovieRental GetById(int id)
            => _repository.GetById(id);

        public void Update(MovieRental entity)
            => _repository.Update(entity);
    }
}