﻿using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Repositories;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace MovieRentalCompany.Domain.Services
{
    public class MovieServices : IServices<Movie>
    {
        private readonly IRepository<Movie> _repository;

        public MovieServices(IRepository<Movie> repository)
        {
            _repository = repository;
        }

        public void Add(Object entity)
        {
            if (entity == null) return;

            var movie = entity as Movie;

            var result = RegisterMovie(movie.Name, movie.Category);
        }

        public List<object> GetAll(Expression<Func<Movie, bool>> condition)
        {
            if(condition == null) return (List<object>)_repository.GetAll();

            //Expression<Func<Movie, bool>> expression = (Expression<Func<Movie, bool>>)condition.Body;

            return (List<object>)_repository.GetByCondition(condition);
        }

        Movie IServices<Movie>.GetById(int id) => _repository.GetById(id);

        public Movie RegisterMovie(string name, string category)
        {
            if (name == null || category == null) return null;
            _repository.Add(new Movie { Name = name, Category = category });

            return new Movie { Name = name, Category = category};
        }

        public void Remove(int id)
        {
            var entity = _repository.GetById(id);

            if (entity == null) return;

            entity.IsDeleted = DateTime.UtcNow;
            entity.IsActive = false;

            _repository.Update(entity);
        }
    }
}