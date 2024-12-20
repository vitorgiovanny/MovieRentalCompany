using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Repositories;
using MovieRentalCompany.Domain.Interfaces.Services;
using System.Linq.Expressions;

namespace MovieRentalCompany.Services.Service
{
    public class CustomerServices : IServices<Customer>
    {
        private readonly IRepository<Customer> _repository;

        public CustomerServices(IRepository<Customer> repository) => _repository = repository;

        public void Add(object entity)
        {
            if ((Customer)entity is { Email: not null, Name: not null, IsActive: true }) Register((Customer)entity);
        }

        public List<object> GetAll(Expression<Func<Customer, bool>> condition)
            => condition == null
                 ? _repository.GetAll().ToList<object>()
                 : _repository.GetByCondition(condition).ToList<object>();

        public Customer? GetByEmail(string email) =>
            _repository.GetByCondition(customers => customers.Email == email)?.FirstOrDefault();

        public Customer GetById(int id) => _repository.GetById(id);

        private void Register(Customer customer)
            => _repository.Add(customer);

        public void Remove(int id)
        {
            var customer = _repository.GetById(id) ?? throw new Exception("Error, objeto não encontrado");

            customer.IsActive = false;
            _repository.Update(customer);
        }

        public void Update(Customer entity)
            => _repository.Update(entity);

        public List<Customer> GetAll() => (List<Customer>)_repository.GetAll();
    }
}