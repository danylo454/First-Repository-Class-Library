using Company.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Data.Interfaces
{
    public interface IcompanyRepository
    {
        void AddCompany(ITCompany company);
        void RemoveCompany(int id);
        bool GetIfCompanyExist(int id);
        void ShowAllCompany();
        void UpdateCompany(int id,string name);
        void ShowCompanyById(int id);
        void ShowCompanyByName(string name);
    }
}
