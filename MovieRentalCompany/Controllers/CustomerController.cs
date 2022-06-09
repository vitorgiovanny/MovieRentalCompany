using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Domain.Interfaces.Services;
using MovieRentalCompany.Domain.Models;
using MovieRentalCompany.ViewModel;

namespace MovieRentalCompany.Controllers
{
    [ApiController]
    [Route("Customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerServices _services;

        public CustomerController(ICustomerServices services)
        {
            _services = services;
        }
        /// <summary>
        /// Adicionar Cliente
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult RegisterCustomer(NewCustomer customer)
        {
            var searchEmail = _services.GetByEmail(customer.Email);

            if(searchEmail == null)
            {
                var register = _services.Register(customer.Name, customer.LasName, customer.Email);

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
