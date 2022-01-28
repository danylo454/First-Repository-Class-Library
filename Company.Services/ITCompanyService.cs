using Company.Data.Data.Classes;
using Company.Data.Data.Interfaces;
using Company.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services
{
    public class ITCompanyService
    {
        private readonly IcompanyRepository _companyRepository;
        public ITCompanyService(IcompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        public void AddCompany()
        {
            Console.Clear();
            Console.Write("Enter Name Company: ");
            string name = Console.ReadLine();
            ITCompany company = new ITCompany
            {
                Name = name
            };
            _companyRepository.AddCompany(company);
        }
        public void DeleteCompany()
        {
            Console.Clear();
            Console.Write("Enter id company which you want delete: ");
            int id = int.Parse(Console.ReadLine());
            try
            {
                bool ifExist = _companyRepository.GetIfCompanyExist(id);
                if (ifExist == true)
                {
                    _companyRepository.RemoveCompany(id);
                }
                else
                {
                    Console.WriteLine($"Company with Id:{id} does not exist!!!");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void ShowAllCompany()
        {
            _companyRepository.ShowAllCompany();
        }
        public void UpdateCompany()
        {
            Console.Clear();
            Console.Write("Enter id company which you want to update: ");
            int id = int.Parse(Console.ReadLine());
            bool flag = _companyRepository.GetIfCompanyExist(id);
            if (flag == true)
            {
                Console.Write("Enter new name: ");
                string name = Console.ReadLine();
                _companyRepository.UpdateCompany(id, name);
            }
            else
            {
                Console.WriteLine($"The company with Id: {id} is not exist!!!");
            }
        }
        public void ShowCompanyById()
        {
            Console.Clear();
            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine());
            _companyRepository.ShowCompanyById(id);
        }
        public void ShowCompanyByName()
        {
            Console.Clear();
            Console.Write("Enter name company: ");
            string name = Console.ReadLine();
            _companyRepository.ShowCompanyByName(name);
        }
            
    }
}
