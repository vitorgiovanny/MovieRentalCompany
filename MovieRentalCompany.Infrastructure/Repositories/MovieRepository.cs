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
    public class MovieRepository : IMovieRepository
    {
        private readonly ApplicationDbContext _context;

        public MovieRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Movie> RegisterMovie(string name, string category)
        {
            var movie = new Movie
            {
                Name = name,
                Category = category,
                IsActive = true
            };

            await _context.Movie.AddAsync(movie);
            await _context.SaveChangesAsync();

            return movie;
        }

        public void Update(Movie movie)
        {
             _context.Movie.Update(movie);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetById(int id)
        {
            return await _context.Movie.FirstOrDefaultAsync(mr => mr.Id == id);
        }
    }
}
