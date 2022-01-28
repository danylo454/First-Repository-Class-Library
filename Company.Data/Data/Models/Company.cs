using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Data.Models
{
    public class ITCompany
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User>? Users { get; set; }
    }
}
