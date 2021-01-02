using System;
namespace HospitalApp.Submenus
{
    public class AdminSubmenu: Abstracts.Submenu
    {
        public AdminSubmenu(string whoLoggedIn)
        {
            this.FullName = whoLoggedIn;

            while (true)
            {
                Console.WriteLine($"Welcome {FullName}. Please select an option from menu below:\n\n");

                Console.WriteLine("1. Show all users.\n" +
                    "2. Show duties schedule\n" +
                    "3. Edit schedule\n" +
                    "4. Add user\n\n" +
                    "0. Return to main menu");

                int selection = int.Parse(Console.ReadLine());

                if (selection == 1)
                {
                    int iter = 1;
                    foreach (var item in data.Nurses)
                    {
                        Console.WriteLine($"{iter}. {item.FullName} - {item.Role}");
                        iter++;
                    }
                    foreach (var item in data.Doctors)
                    {
                        Console.WriteLine($"{iter}. {item.FullName} - {item.Role}, {item.Specialization}");
                        iter++;
                    }
                    foreach (var item in data.Administrators)
                    {
                        Console.WriteLine($"{iter}. {item.FullName} - {item.Role}");
                    }
                    holder();
                }
                else if (selection == 2)
                {
                    Console.Clear();
                    int check = 0;
                    Console.WriteLine("Enter the name and surname for a person you'd like to see a schedule.");
                    string person = Console.ReadLine().ToLower();
                    foreach (var item in data.Nurses)
                    {
                        if (person == item.FullName.ToLower())
                        {
                            item.ShowShifts();
                        }
                        else
                        {
                            check++;
                        }
                    }
                    foreach (var item in data.Doctors)
                    {
                        if (person == item.FullName.ToLower())
                        {
                            item.ShowShifts();
                        }
                        else
                        {
                            check++;
                        }
                    }
                    if (check == (data.Nurses.Count + data.Doctors.Count))
                    {
                        Console.WriteLine("No such person found. Please try again.");
                    }
                    holder();
                }
                else if (selection == 3)
                {
                    Console.Clear();
                    int check = 0;
                    Console.WriteLine("Enter name and surname for person you'd like to make changes in schedules.");
                    string person = Console.ReadLine().ToLower();
                    foreach (var item in data.Nurses)
                    {
                        if (person == item.FullName.ToLower())
                        {
                            new AdminSchedulesSubmenu(person);
                        }
                        else
                        {
                            check++;
                        }
                    }
                    foreach (var item in data.Doctors)
                    {
                        if (person == item.FullName.ToLower())
                        {
                            new AdminSchedulesSubmenu(person);
                        }
                        else
                        {
                            check++;
                        }
                    }
                    if (check == (data.Nurses.Count + data.Doctors.Count))
                    {
                        Console.WriteLine("No such person found. Please try again.");
                    }
                    holder();

                }
                else if (selection == 4)
                {
                    Console.Clear();
                    new AdminCreationSubmenu(whoLoggedIn);
                }
                else if (selection == 0)
                {
                    data.DataExport();
                    Console.Clear();
                    new Menu();
                }
            }

        }


    }
}
