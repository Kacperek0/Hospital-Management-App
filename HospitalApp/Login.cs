using System;
using System.Linq;
using System.Threading;

namespace HospitalApp
{
    public class Login
    {
        protected Data data;
        protected string login;
        protected string password;

        public Login()
        {
            data = new Data();

            while (true)
            {
                Console.WriteLine
                        (
                            "------ Hospital Mgmt App ------\n" +
                            $"Log in\n" +
                            $"\n"
                        );
                Console.WriteLine("Please input your login or type 0 to return to the main menu.\n");
                login = Console.ReadLine();
                if (login == "0")
                {
                    data.DataExport();
                    new Menu();
                }
                else
                {
                    Console.WriteLine("Please input your password.");
                    password = Console.ReadLine();

                    Console.WriteLine(data.IsLoggedIn(login, password));

                    string credentials = data.IsLoggedIn(login, password);

                    if (credentials == "admin")
                    {
                        Console.WriteLine("admSubmenu here");
                    }
                    else if (credentials == "doctor")
                    {
                        Console.WriteLine("Doc login menu");
                    }
                    else if (credentials == "nurse")
                    {
                        Console.WriteLine("Nurse login");
                    }
                    else
                    {
                        Console.WriteLine("Login has failed. Please try again...");
                        Thread.Sleep(1000);
                    }
                }
            }
        }

    }
}