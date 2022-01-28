using Company.Data.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Data.Initializer
{
    public static class DbInitializer
    {
        public static void Seed(this ModelBuilder modelBuiler)
        {
            modelBuiler.Entity<ITCompany>().HasData
                (
                new ITCompany
                {
                    Id = 1,
                    Name = "Microsoft"
                }
                );
            modelBuiler.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    Name = "Bill",
                    Surname = "Gates",
                    Position = "CEO",
                    Salary = 300000,
                    CompanyID = 1
                    
                },
                new User
                {
                    Id = 2,
                    Name = "Tim",
                    Surname = "Ridgers",
                    Position = "Developer",
                    Salary = 8000,
                    CompanyID = 1

                }
                );

        }
    }
}
