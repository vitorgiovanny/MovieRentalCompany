using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Interfaces.Services
{
    public interface ICustomerServices
    {
        bool Register(string name, string lastname, string email);
    }
}
