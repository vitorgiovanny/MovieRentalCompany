using MovieRentalCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Interfaces.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> RegisterMovie(string name, string category);
        void Update(Movie movie);
        Task<int> Save();
        Task<Movie> GetById(int id);
    }
}
