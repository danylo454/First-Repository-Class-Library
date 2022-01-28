using Company.Data.Data.Interfaces;
using Company.Data.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data.Data.Classes
{
    public class UserRepository : IUserRepository
    {
        public void AddUser(User user)
        {
            using (AppDbContext context = new AppDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }

        public void DeleteUser(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                bool flag = context.Users.Where(u => u.Id == id).Any();
                if (flag == true)
                {
                    User user = context.Users.FirstOrDefault(u => u.Id == id);
                    context.Users.Remove(user);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine($"The User with Id: {id} is not exist!!!");
                }
            }
        }

        public bool GetUserIfExist(int id)
        {
            bool flag = false;
            using (AppDbContext context = new AppDbContext())
            {
                flag = context.Users.Where(u => u.Id == id).Any();
            }
            return flag;
        }

        public void ShowAllUsers()
        {
            using (AppDbContext context = new AppDbContext())
            {
                var users = context.Users;
                foreach (var user in users)
                {
                    Console.WriteLine(new String('=', 30));
                    Console.WriteLine($"Id: {user.Id}\n" +
                        $"Full Name: {user.Name}  {user.Surname}\n" +
                        $"Position: {user.Position}\n" +
                        $"Salary: {user.Salary}\n" +
                        $"CompanyID {user.CompanyID}");
                }
            }
        }

        public void ShowUserById(int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                bool flag = context.Users.Where(u => u.Id == id).Any();
                if (flag == true)
                {
                    User user = context.Users.FirstOrDefault(u => u.Id == id);
                    Console.WriteLine($"Id: {user.Id}\n" +
                        $"Full Name: {user.Name}  {user.Surname}\n" +
                        $"Position: {user.Position}\n" +
                        $"Salary: {user.Salary}\n" +
                        $"CompanyID {user.CompanyID}");
                }
                else
                {
                    Console.WriteLine($"The User with Id: {id} is not exist!!!");
                }
            }
        }

        public void ShowUserByName(string name)
        {
            using (AppDbContext context = new AppDbContext())
            {
                bool flag = context.Users.Where(u => u.Name == name).Any();
                if (flag == true)
                {
                    User user = context.Users.FirstOrDefault(u => u.Name == name);
                    Console.WriteLine($"Id: {user.Id}\n" +
                        $"Full Name: {user.Name}  {user.Surname}\n" +
                        $"Position: {user.Position}\n" +
                        $"Salary: {user.Salary}\n" +
                        $"CompanyID {user.CompanyID}");
                }
                else
                {
                    Console.WriteLine($"The User with Name: {name} is not exist!!!");
                }
            }
        }

        public void UpdateUser(User user,int id)
        {
            using (AppDbContext context = new AppDbContext())
            {
                User user2 = context.Users.Where(u =>u.Id == id).FirstOrDefault();
                user2.Position = user.Position;
                user2.Salary = user.Salary;
                user2.CompanyID = user.CompanyID;
                user2.Name = user.Name;
                user2.Surname = user.Surname;
                context.Users.Update(user2);
                context.SaveChanges();
            }
        }
    }
}
