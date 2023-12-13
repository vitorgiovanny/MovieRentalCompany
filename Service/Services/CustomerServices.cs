using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Repositories;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
namespace MovieRentalCompany.Services.Service
{
    public class CustomerServices : IServices<Customer>
    {
        private readonly IRepository<Customer> _repository;

        public CustomerServices(IRepository<Customer> repository) => _repository = repository;

        public void Add(object entity)
        {
            if ((Customer)entity is { Email: not null, Name: not null, IsActive: true })
            {
                Register((Customer)entity);
            }
        }

        public List<object> GetAll(Expression<Func<Customer, bool>> condition)
        {
            if (condition == null) return (List<object>)_repository.GetAll();
            return (List<object>)_repository.GetByCondition(condition);
        }

        public Customer GetByEmail(string email) =>
            _repository.GetByCondition(customers => customers.Email == email)?.FirstOrDefault();

        public Customer GetById(int id) => _repository.GetById(id);

        private void Register(Customer customer)
            => _repository.Add(customer);

        public void Remove(int id)
        {
            var customer = _repository.GetById(id);
            customer.IsActive = false;
            _repository.Update(customer);
        }

        public void Update(Customer entity)
            => _repository.Update(entity);
    }
}