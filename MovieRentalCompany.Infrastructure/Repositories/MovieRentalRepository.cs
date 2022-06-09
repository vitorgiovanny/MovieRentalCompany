using Microsoft.EntityFrameworkCore;
using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Repositories;
using MovieRentalCompany.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Infrastructure.Repositories
{
    public class MovieRentalRepository : IMovieRentalRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MovieRental> Register(int idCustomer, int idMovie, DateTime devolution)
        {
            var rental = new MovieRental
            {
                Id_Customer = idCustomer,
                Id_Movie = idMovie,
                Creater = DateTime.UtcNow,
                PrevisionDevolution = devolution,
            };

            await _context.MovieRental.AddAsync(rental);

            return rental;
        }

        public void Update(MovieRental modal)
        {
            _context.MovieRental.Update(modal);
        }

        public async Task<MovieRental> GetById(int id)
        {
            return await _context.MovieRental.FirstOrDefaultAsync(mr => mr.Id == id);
        }

        public async Task<List<MovieRental>> GetByIdMovie(int id_movie)
        {
            return await _context.MovieRental.Where(mr => mr.Id_Movie == id_movie).ToListAsync();
        }

        public async Task<List<MovieRental>> GetAll()
        {
            return await _context.MovieRental.ToListAsync();
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
