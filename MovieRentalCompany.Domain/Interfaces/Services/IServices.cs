using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Interfaces.Services
{
    public interface IServices<T>
    {
        void Add(object entity);
        void Remove(int id);
        List<object> GetAll(Expression<Func<T, bool>> condition);
        T GetById(int id);
    }
}
