using Microsoft.AspNetCore.Mvc;
using MovieRentalCompany.Domain.Interfaces.Services;
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

        [HttpPost]
        public IActionResult RegisterCustomer(NewCustomer customer)
        {
            var searchEmail = _services.GetByEmail(customer.Email);

            if(searchEmail == null)
            {
                return Ok(_services.Register(customer.Name, customer.LasName, customer.Email));
            }

            return null;
        }
    }
}
