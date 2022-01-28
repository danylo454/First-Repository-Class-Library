using Company.Data.Data.Classes;
using Company.Data.Data.Models;
using Company.Services;

class Program
{
    static void Main(string[] args)
    {
        ITCompanyService serviceCompany = new ITCompanyService(new CompanyRepository());
        ITUsersService usersService = new ITUsersService(new UserRepository());
        int exit = -1;
        do
        {
            Console.Clear();
            Console.Write($"1)Company\n" +
                $"2)Users\n" +
                $"0)Exit\n" +
                $"Enter: ");
            exit = int.Parse(Console.ReadLine());
            if (exit == 1)
            {
                Console.Clear();
                int company = -1;
                do
                {
                    Console.Write("1)Add Company\n" +
                        "2)Delete Company\n" +
                        "3)Update Company\n" +
                        "4)Show All Company\n" +
                        "5)Show by id\n" +
                        "6)Show by name\n" +
                        "0)Exit\n" +
                        "Enter: ");
                    company = int.Parse(Console.ReadLine());
                    switch (company)
                    {
                        case 1: { serviceCompany.AddCompany(); break; }
                        case 2: { serviceCompany.DeleteCompany(); break; }
                        case 3: { serviceCompany.UpdateCompany(); break; }
                        case 4: { serviceCompany.ShowAllCompany(); break; }
                        case 5: { serviceCompany.ShowCompanyById(); break; }
                        case 6: { serviceCompany.ShowCompanyByName(); break; }
                        case 0: { company = 0; break; }
                        default: { Console.Clear();break; }
                    }
                } while (company != 0);
            }
            if (exit == 2)
            {
                Console.Clear();
                int user = -1;
                do
                {
                    Console.Write("1)Add User\n" +
                        "2)Delete User\n" +
                        "3)Update User\n" +
                        "4)Show All User\n" +
                        "5)Show by id\n" +
                        "6)Show by name\n" +
                        "0)Exit\n" +
                        "Enter: ");
                    user = int.Parse(Console.ReadLine());
                    switch (user)
                    {
                        case 1: { usersService.AddUser(); break; }
                        case 2: { usersService.DeleteUser(); break; }
                        case 3: { usersService.UpdateUser(); break; }
                        case 4: { usersService.ShowAllUsers(); break; }
                        case 5: { usersService.ShowUserById(); break; }
                        case 6: { usersService.ShowUserByName(); break; }
                        case 0: { user = 0; break; }
                        default: { Console.Clear(); break; }
                    }
                } while (user != 0);
            }

        } while (exit != 0);
      

    }
}