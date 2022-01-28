using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Data.Models
{
    public class User
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Position { get; set; }
        public int? Salary { get; set; }
        public int? CompanyID { get; set; }
        public ITCompany? Company { get; set; }
    }
}
