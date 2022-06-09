using MovieRentalCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Interfaces.Repositories
{
    public interface IMovieRentalRepository
    {
        Task<MovieRental> Register(int idCustomer, int idMovie, DateTime devolution);
        Task<List<MovieRental>> GetByIdMovie(int id_movie);
        Task<List<MovieRental>> GetAll();
        Task<MovieRental> GetById(int id);
        void Update(MovieRental modal);
        Task<int> Save();
    }
}
