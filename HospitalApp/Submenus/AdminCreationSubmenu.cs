using System;

namespace HospitalApp.Submenus
{
    internal class AdminCreationSubmenu
    {
        Data data;

        public AdminCreationSubmenu(string whoLoggedIn)
        {
            while (true)
            {
                data = new Data();
                Console.WriteLine("Please select which user type you'd like to create:\n" +
                    "1. Nurse\n" +
                    "2. Doctor\n" +
                    "5. Admin\n\n" +
                    "9. Back to Admin Panel\n" +
                    "0. Back to Main Menu");
                int select = int.Parse(Console.ReadLine());

                if (select == 1)
                {
                    Console.Clear();
                    Console.WriteLine("--- Add nurse ---\n");
                    Console.WriteLine("Enter name:\n");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter surname\n");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Enter PESEL number:\n");
                    string PESEL = Console.ReadLine();
                    Console.WriteLine("Enter login:\n");
                    string login = Console.ReadLine();
                    Console.WriteLine("Enter password:");
                    string password = Console.ReadLine();

                    data.AddNurse(name, surname, PESEL, login, password);
                    data.DataExport();
                }
                else if (select == 2)
                {
                    Console.Clear();
                    Console.WriteLine("--- Add doctor ---\n");
                    Console.WriteLine("Enter name:\n");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter surname\n");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Enter PESEL number:\n");
                    string PESEL = Console.ReadLine();
                    Console.WriteLine("Enter login:\n");
                    string login = Console.ReadLine();
                    Console.WriteLine("Enter password:");
                    string password = Console.ReadLine();
                    Console.WriteLine("Enter PWZ number");
                    int pwz = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter specialization");
                    string spec = Console.ReadLine();

                    data.AddDoctor(name, surname, PESEL, login, password, pwz, spec);
                    data.DataExport();
                }
                else if (select == 5)
                {
                    Console.Clear();
                    Console.WriteLine("--- Add nurse ---\n");
                    Console.WriteLine("Enter name:\n");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter surname\n");
                    string surname = Console.ReadLine();
                    Console.WriteLine("Enter PESEL number:\n");
                    string PESEL = Console.ReadLine();
                    Console.WriteLine("Enter login:\n");
                    string login = Console.ReadLine();
                    Console.WriteLine("Enter password:");
                    string password = Console.ReadLine();

                    data.AddAdmin(name, surname, PESEL, login, password);
                    data.DataExport();
                }
                else if (select == 9)
                {
                    Console.Clear();
                    data.DataExport();
                    new AdminSubmenu(whoLoggedIn);
                }
                else if (select == 0)
                {
                    Console.Clear();
                    data.DataExport();
                    new Menu();
                }
            }
        }
    }
}