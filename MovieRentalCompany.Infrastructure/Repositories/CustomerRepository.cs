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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Register(string name, string lastname, string email)
        {
            var customers = new Customer
            {
                Name = name,
                LastName = lastname,
                Email = email,
                IsActive = true,
            };

            try
            {
                await _context.Customer.AddAsync(customers);

            }
            catch (Exception ex)
            {
                var message = ex;
            }

            return customers;
        }

        public async Task<Customer> GetByEmail(string email)
        {
            return await _context.Customer.AsNoTracking().FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<int> Save()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                var message = ex;
                return 0;
            }
        }
    }
}
