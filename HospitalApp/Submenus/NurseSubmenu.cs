using System;
namespace HospitalApp.Submenus
{
    public class NurseSubmenu: Abstracts.Submenu
    {
        public NurseSubmenu(string whoLoggedIn)
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
                            check++;;
                        }
                    }
                    Console.WriteLine(check);
                    if (check == data.Nurses.Count)
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
