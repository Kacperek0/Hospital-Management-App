using System;
using System.Linq;
using System.Threading;
using HospitalApp.Submenus;

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

                    foreach (var item in data.Administrators)
                    {
                        if (item.Login(login, password))
                        {
                            string whoLoggedIn = item.FullName;
                            Console.Clear();
                            new AdminSubmenu();
                        }
                    }
                    foreach (var item in data.Doctors)
                    {
                        if (item.Login(login,password))
                        {
                            string whoLoggedIn = item.FullName;
                            Console.Clear();
                            new DoctorSubmenu(whoLoggedIn);
                        }
                    }
                    foreach (var item in data.Nurses)
                    {
                        if (item.Login(login, password))
                        {
                            string whoLoggedIn = item.FullName;
                            Console.Clear();
                            new NurseSubmenu(whoLoggedIn);
                        }
                        else
                        {
                            Console.WriteLine("Login has failed. Please try again");
                            Thread.Sleep(2000);
                            Console.Clear();
                        }
                    }
                }
            }
        }

        public string[] Credentials()
        {
            string[] cred = new string[] { login, password };
            return cred;
        }
    }
}