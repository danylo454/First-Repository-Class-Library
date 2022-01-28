using Company.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Data.Interfaces
{
    public interface IUserRepository
    {
        public void AddUser(User user);
        public void UpdateUser(User user,int id);
        public void DeleteUser(int id);
        public void ShowAllUsers();
        public void ShowUserById(int id);
        public void ShowUserByName(string name);
        public bool GetUserIfExist(int id);

    }
}
