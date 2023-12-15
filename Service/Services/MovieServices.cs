using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Repositories;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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


        /// <summary>
        /// Get dates by Expression
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<object> GetAll(Expression<Func<Movie, bool>> condition)
        {
            List<object> listResponse = new List<object>();

            var response = _repository.GetAll().ToList();
            listResponse.AddRange(response);

            //Refatorar o codigo
            if (condition == null) return listResponse;

            var result = new List<object>();
            result.AddRange(_repository.GetByCondition(condition));

            return result;
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

        public void Update(Movie entity)
            => _repository.Update(entity);

        public List<Movie> GetAll()
            => (List<Movie>)_repository.GetAll();
    }
}