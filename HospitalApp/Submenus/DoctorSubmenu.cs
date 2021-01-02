using System;
namespace HospitalApp.Submenus
{
    public class DoctorSubmenu: Abstracts.Submenu
    {
        public DoctorSubmenu(string whoLoggedIn)
        {
            this.FullName = whoLoggedIn;

            while (true)
            {
                Console.WriteLine($"Welcome {FullName}. Please select an option from menu below:\n\n");

                Console.WriteLine("1. Show all colleagues.\n" +
                    "2. Show duties schedule\n\n" +
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
                    holder();
                }
                else if (selection == 2)
                {
                    Console.Clear();

                    Console.WriteLine("Enter the name and surname for a person you'd like to see a schedule.");
                    string person = Console.ReadLine().ToLower();
                    int check = 0;
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
                else if (selection == 0)
                {
                    Console.Clear();
                    new Menu();
                }
            }
        }
    }
}
