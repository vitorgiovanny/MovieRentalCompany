using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Entities.ComplexType
{
    public class ReturnMovie
    {
        public DateTime PrevisionDevolution { get; set; }

        public ReturnMovie(DateTime date)
        {
            PrevisionDevolution = date.AddDays(3);
        }
    }
}
