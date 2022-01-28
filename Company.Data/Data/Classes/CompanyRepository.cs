using Company.Data.Data.Interfaces;
using Company.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Data.Classes
{
    public class CompanyRepository : IcompanyRepository
    {
        public void AddCompany(ITCompany company)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.ITCompanies.Add(company);
                context.SaveChanges();
            }
        }
        public void RemoveCompany(int Id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                ITCompany company = context.ITCompanies.FirstOrDefault(x => x.Id == Id);
                context.ITCompanies.Remove(company);
                context.SaveChanges();
            }
        }
        public bool GetIfCompanyExist(int Id)
        {
            bool flag = false;
            using (AppDbContext context = new AppDbContext())
            {
                flag = context.ITCompanies.Where(c => c.Id == Id).Any();
            }
            return flag;
        }
        public void ShowAllCompany()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var companyes = context.ITCompanies;
                if (companyes.Count() == 0)
                {
                    Console.WriteLine("Companies are empty");
                }
                else
                {
                    foreach (var company in companyes)
                    {
                        Console.WriteLine($"Id: {company.Id}\n" +
                            $"Name: {company.Name}\n");
                    }

                }
            }
        }
        public void UpdateCompany(int id, string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                var company = context.ITCompanies.Where(c => c.Id == id).FirstOrDefault();
                company.Name = name;
                context.SaveChanges();
            }
        }

        public void ShowCompanyById(int id)
        {
            bool init = GetIfCompanyExist(id);
            if (init == true)
            {
                using (AppDbContext context = new AppDbContext())
                {
                    var company = context.ITCompanies.Where(c => c.Id == id).FirstOrDefault();
                    Console.WriteLine($"Id: {company.Id}\n" +
                           $"Name: {company.Name}\n");
                }
            }
            else
            {
                Console.WriteLine($"The company with id {id} is not exist");
            }
        }

        public void ShowCompanyByName(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                bool flag = context.ITCompanies.Where(c => c.Name == name).Any();
                if (flag == true)
                {
                    var company = context.ITCompanies.Where(c => c.Name == name).FirstOrDefault();
                    Console.WriteLine($"Id: {company.Id}\n" +
                           $"Name: {company.Name}\n");
                }
                else
                {
                    Console.WriteLine($"The company with Name {name} is not exist");
                }
            }
        }
    }
}
