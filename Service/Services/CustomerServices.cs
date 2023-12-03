using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Repositories;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace MovieRentalCompany.Services.Service
{
    public class CustomerServices : ICustomerServices
    {
        private readonly IRepository<Customer> _repository;

        public CustomerServices(IRepository<Customer> repository) => _repository = repository;

        public Customer GetByEmail(string email) =>
            _repository.GetByCondition(customers => customers.Email == email)?.FirstOrDefault();


        public bool Register(string name, string lastname, string email)
        {
            try
            {
                _repository.Add(new Customer { Name = name, LastName = lastname, Email = email });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}