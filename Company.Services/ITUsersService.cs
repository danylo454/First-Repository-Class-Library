using Company.Data.Data;
using Company.Data.Data.Interfaces;
using Company.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services
{
    public class ITUsersService
    {
        private readonly IUserRepository _userRepository;
        public ITUsersService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public void AddUser()
        {
            Console.Clear();
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Enter Position: ");
            string position = Console.ReadLine();
            Console.Write("Enter Salary: ");
            int salary = int.Parse(Console.ReadLine());
            Console.Write("Enter CompanyId: ");
            int idC = int.Parse(Console.ReadLine());
            User user = new User()
            {
                Name = name,
                Surname = surname,
                Position = position,
                Salary = salary,
                CompanyID = idC
            };
            _userRepository.AddUser(user);
        }
        public void DeleteUser()
        {
            Console.Clear();
            Console.Write("Enter id user which you want to delete: ");
            int id = int.Parse(Console.ReadLine());
            bool flag = _userRepository.GetUserIfExist(id);
            if (flag == true)
            {
                _userRepository.DeleteUser(id);
            }
            else
            {
                Console.WriteLine($"The user with Id: {id} is not exist!!!");
            }
        }
        public void ShowAllUsers()
        {
            Console.Clear();
            _userRepository.ShowAllUsers();
        }
        public void ShowUserById()
        {
            Console.Clear();
            Console.Write("Enter id: ");
            int id = int.Parse(Console.ReadLine());
            _userRepository.ShowUserById(id);
        }
        public void ShowUserByName()
        {
            Console.Clear();
            Console.Write("Enter name: ");
            string name = Console.ReadLine();
            _userRepository.ShowUserByName(name);
        }
        public void UpdateUser()
        {
            Console.Write("Enter id: ");
            int id = int.Parse(Console.ReadLine());
            bool flag = _userRepository.GetUserIfExist(id);
            if (flag == true)
            {
                Console.Clear();
                Console.WriteLine("============= | OLD USER | ============");
                _userRepository.ShowUserById(id);
                Console.WriteLine(new String('=', 30));
                Console.Write("Enter New Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter New Surname: ");
                string surname = Console.ReadLine();
                Console.Write("Enter New Salary: ");
                int salary = int.Parse(Console.ReadLine());
                Console.Write("Enter New Position: ");
                string position = Console.ReadLine();
                Console.Write("Enter New IdCompany: ");
                int idC = int.Parse(Console.ReadLine());
                bool flagId = true;
                using (AppDbContext context = new AppDbContext())
                {
                    flagId = context.ITCompanies.Where(c => c.Id == idC).Any();
                }
                if (flagId == true)
                {
                    User user = new User()
                    {
                        Name = name,
                        Salary = salary,
                        Surname = surname,
                        Position = position,
                        CompanyID = idC
                    };
                    _userRepository.UpdateUser(user, id);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Error!!!");
                }
            }
        }
    }
}
