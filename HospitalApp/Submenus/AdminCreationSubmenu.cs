using System;
using System.Threading;

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
                Console.Clear();
                Console.WriteLine("Please select which user type you'd like to create:\n" +
                    "1. Nurse\n" +
                    "2. Doctor\n" +
                    "5. Admin\n\n" +
                    "9. Back to Admin Panel\n" +
                    "0. Back to Main Menu");
                int select = int.Parse(Console.ReadLine());

                if (select == 1)
                {
                    int check = 0;
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

                    foreach (var item in data.Nurses)
                    {
                        if (name != item.Name && surname != item.Surname)
                        {
                            check++;
                        }
                        if (PESEL != item.PESEL)
                        {
                            check++;
                        }
                        if (loginUniquity(login))
                        {
                            check++;
                        }
                    }

                    if (check == (3 * data.Nurses.Count))
                    {
                        data.AddNurse(name, surname, PESEL, login, password);
                        data.DataExport();
                    }
                    else
                    {
                        Console.WriteLine("Adding new nurse has failed. Please try again.");
                    }
                            
                }
                else if (select == 2)
                {
                    int check = 0;
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
                    if (spec.ToLower() == "cardiologist" || spec.ToLower() == "urologist"
                        || spec.ToLower() == "neurologist" || spec.ToLower() == "laryngologist")
                    {
                        foreach (var item in data.Doctors)
                        {
                            if (name != item.Name && surname != item.Surname)
                            {
                                check++;
                            }
                            if (PESEL != item.PESEL)
                            {
                                check++;
                            }
                            if (loginUniquity(login))
                            {
                                check++;
                            }
                            if (pwz != item.PWZnumber)
                            {
                                check++;
                            }
                        }
                        if (check == (4 * data.Doctors.Count))
                        {
                            data.AddDoctor(name, surname, PESEL, login, password, pwz, spec);
                            data.DataExport();
                        }
                        else
                        {
                            Console.WriteLine("Adding new doctor has failed. Please try again.");
                        }

                    }
                    else
                    {
                        Console.WriteLine("There are only 4 available specializations. Please try again with one of them:\n" +
                            "1. Cardiologist\n" +
                            "2. Urologist\n" +
                            "3. Neurologist\n" +
                            "4. Laryngologist\n\n");
                        Thread.Sleep(1000);
                    }


                }
                else if (select == 5)
                {
                    int check = 0;
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

                    foreach (var item in data.Administrators)
                    {
                        if (name != item.Name && surname != item.Surname)
                        {
                            check++;
                        }
                        if (PESEL != item.PESEL)
                        {
                            check++;
                        }
                        if (loginUniquity(login))
                        {
                            check++;
                        }
                    }

                    if (check == (3 * data.Administrators.Count))
                    {
                        data.AddAdmin(name, surname, PESEL, login, password);
                        data.DataExport();
                    }
                    else
                    {
                        Console.WriteLine("Adding new admin has failed. Please try again.");
                    }


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

        private bool loginUniquity(string login)
        {
            int check = 0;
            int total = data.Nurses.Count + data.Doctors.Count + data.Administrators.Count;
            foreach (var item in data.Nurses)
            {
                if (login != item.login)
                {
                    check++;
                }
            }
            foreach (var item in data.Doctors)
            {
                if (login != item.login)
                {
                    check++;
                }
            }
            foreach (var item in data.Administrators)
            {
                if (login != item.login)
                {
                    check++;
                }
            }

            if (check == total)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}