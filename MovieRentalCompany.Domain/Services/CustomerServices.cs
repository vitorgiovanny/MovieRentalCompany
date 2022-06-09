using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Repositories;
using MovieRentalCompany.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _repository;

        public CustomerServices(ICustomerRepository repository)
        {
            _repository = repository;
        }
        
        public Customer GetByEmail(string email)
        {
            return _repository.GetByEmail(email).Result;
        }

        public bool Register(string name, string lastname, string email)
        {
            var customer = _repository.Register(name, lastname, email).Result;
            var save = _repository.Save().Result;


            if (customer != null) return true;

            return false;
        }
    }
}
