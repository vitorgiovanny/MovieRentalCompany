using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalCompany.ViewModel
{
    public class ResponseMessageJson
    {
        public const string Error = "ERROR";
        public const string Success = "SUCCESS";

        public string Type { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public object Parameters { get; set; }
    }
}
