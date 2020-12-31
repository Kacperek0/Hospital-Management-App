using System;
using System.Linq;
using System.Threading;

namespace HospitalApp
{
    public class Login: Menu
    {
        protected string login;
        protected string password;

        private int[] admLogin = new int[] { 1, 0 };
        private int[] doctorLogin = new int[] { 1, 1 };
        private int[] nurseLogin = new int[] { 1, 2 };
        private int[] failedLogin = new int[] { 0, 0 };

        public Login()
        {

        }

        public void Run()
        {
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
                    new Menu();
                }
                else
                {
                    Console.WriteLine("Please input your password.");
                    password = Console.ReadLine();

                    int[] credentials = Data.IsLoggedIn(login, password);

                    if (credentials.SequenceEqual(admLogin))
                    {
                        Console.WriteLine("admSubmenu here");
                    }
                    else if (credentials.SequenceEqual(doctorLogin))
                    {
                        Console.WriteLine("Doc login menu");
                    }
                    else if (credentials.SequenceEqual(nurseLogin))
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