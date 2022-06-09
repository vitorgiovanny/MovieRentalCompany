using MovieRentalCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Interfaces.Services
{
    public interface IMovieServices
    {
        Movie RegisterMovie(string name, string category);
        bool RemoveMovie(int id);
    }
}
