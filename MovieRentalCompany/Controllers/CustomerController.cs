using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Domain.Entities;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.Domain.Models;
using MovieRentalCompany.Infrastructure.Database.Context;
using MovieRentalCompany.ViewModel;

namespace MovieRentalCompany.Controllers
{
    [ApiController]
    [Route("Customer")]
    public class CustomerController : VideoRentalStoreGenericController<Customer, IServices<Movie>>
    {
        //private readonly ICustomerServices _services;
        private readonly IServices<Customer> _services;
        public CustomerController(IServices<Customer> services) : base(services) 
        {
            _services = services;
        }

        /// <summary>
        /// Adicionar Cliente
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        /// 
        [HttpPost]
        public IActionResult RegisterCustomer(NewCustomer customer)
        {
            var searchEmail = _services.GetAll(email => email.Email == customer.Email).FirstOrDefault();

            if(searchEmail == null)
            {
                _services.Add(new Customer { Name = customer.Name, LastName = customer.LasName, Email = customer.Email });

                return Ok(new ResponseMessageJson
                {
                    Type = ResponseMessageJson.Success,
                    Code = ResponseCodes.CustomerSuccess,
                    Description = "Bem vindo, registrado com sucesso."
                });

            }

            return BadRequest(new ResponseMessageJson
            {
                Type = ResponseMessageJson.Error,
                Code = ResponseCodes.CustomerError,
                Description = "Esse usuario já tem cadastro aqui"
            });
        }
    }
}
