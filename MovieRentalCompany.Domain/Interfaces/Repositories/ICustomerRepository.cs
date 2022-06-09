using MovieRentalCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Interfaces.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> Register(string name, string lastname, string email);
        Task<Customer> GetByEmail(string email);
        Task<int> Save();
    }
}
