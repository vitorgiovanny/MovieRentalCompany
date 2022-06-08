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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Customer> Register(string name, string lastname, string email)
        {
            var customer = new Customer
            {
                Name = name,
                LastName = lastname,
                Email = email,
                IsActive = true,
            };

            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();

            return customer;
        }
    }
}
