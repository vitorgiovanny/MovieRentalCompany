using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Entities
{
    public class MovieRental
    {
        public int Id { get; set; }
        public int Id_Customer { get; set; }
        public int Id_Movie { get; set; }
        public DateTime Creater { get; set; }
        public DateTime? Devolution { get; set; }
        public DateTime PrevisionDevolution { get; set; }
        public DateTime? Canceled { get; set; }

        //Relationship
        public Movie Movies { get; set; }
        public Customer Customers { get; set; }
    }
}
