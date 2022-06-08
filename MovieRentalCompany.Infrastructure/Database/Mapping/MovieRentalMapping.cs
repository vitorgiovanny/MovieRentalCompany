using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieRentalCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Infrastructure.Database.Mapping
{
    public class MovieRentalMapping : IEntityTypeConfiguration<MovieRental>
    {
        public void Configure(EntityTypeBuilder<MovieRental> builder)
        {
            builder.HasIndex(b => b.Id);

            builder.HasOne(mr => mr.Customers)
                .WithMany(c => c.MovieRentals)
                .HasForeignKey(mr => mr.Id_Customer);

            builder.HasOne(mr => mr.Movies)
                .WithMany(m => m.MovieRentals)
                .HasForeignKey(mr => mr.Id_Movie);
        }
    }
}
