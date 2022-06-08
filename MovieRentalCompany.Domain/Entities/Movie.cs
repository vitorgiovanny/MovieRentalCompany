using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsActive { get; set; }
        public DateTime? IsDeleted { get; set; }

        //Relationship Icollection
        public ICollection<MovieRental> MovieRentals { get; set; }
    }
}
