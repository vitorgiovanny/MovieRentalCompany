using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Services;

namespace MovieRentalCompany.Test
{
    public class AddMovieFake : IMovieServices
    {
        private readonly Movie _movie;
    
        public AddMovieFake()
        {
            _movie = new Movie
            {
                Id = 1,
                Name = "Filme fake",
                Category = "Categoria fake",
                IsActive = true
            };
        }

        public Movie RegisterMovie(string name, string category)
        {
            var movies = new Movie
            {
                Name = "Novo Filme fake",
                Category = "Nova Categoria fake",
                IsActive = true
            };

            _movie.Name = movies.Name;
            _movie.Category = movies.Category;
            _movie.IsActive = movies.IsActive;

            return _movie;
        }

        public bool RemoveMovie(int id)
        {
            if(_movie.Id != id)
            {
                return false;
            }

            _movie.IsActive = false;
            _movie.IsDeleted = DateTime.UtcNow;

            return true;
            
        }
    }
}