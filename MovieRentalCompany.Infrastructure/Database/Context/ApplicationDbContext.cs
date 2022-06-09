using Microsoft.EntityFrameworkCore;
using MovieRentalCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Infrastructure.Database.Context
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<MovieRental> MovieRental { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
