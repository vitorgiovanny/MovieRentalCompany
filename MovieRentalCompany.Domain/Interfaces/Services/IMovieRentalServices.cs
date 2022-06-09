using MovieRentalCompany.Domain.DTOs;
using MovieRentalCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Interfaces.Services
{
    public interface IMovieRentalServices
    {
        MovieRental Register(int id_Customer, int id_Movie);
        DevolutionDTO Devlotuion(int id);
        bool Canceled(int id);
    }
}
