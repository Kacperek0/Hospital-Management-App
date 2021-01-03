using System;
using HospitalEmployees;

namespace HospitalApp.Submenus
{
    internal class AdminSchedulesSubmenu
    {
        private Data data;
        private string person;


        public AdminSchedulesSubmenu(string person)
        {
            this.person = person;

            while (true)
            {
                data = new Data();

                Console.WriteLine($"You are now editing schedule of: {person}.\n" +
                    $"Current schedule plan for this person is:\n");
                currentSchedule();

                Console.WriteLine($"Please select an option from menu below:\n\n");

                Console.WriteLine("1. Add shift.\n" +
                    "2. Remove shift\n\n" +
                    "0. Return to main menu");

                int selection = int.Parse(Console.ReadLine());

                if (selection == 1)
                {
                    Console.Clear();

                    Console.WriteLine("Current schedule:\n");
                    currentSchedule();
                    Console.WriteLine("Please enter a date of a duty you'd like to add.");
                    int newDuty = int.Parse(Console.ReadLine());
                    foreach (var item in data.Nurses)
                    {
                        if (person == item.FullName.ToLower())
                        {
                            if (item.Shifts.Contains(newDuty + 1) || item.Shifts.Contains(newDuty - 1))
                            {
                                Console.WriteLine("Unable to add. Shifts cannot happen day by day.");
                            }
                            else
                            {
                                item.AddShift(newDuty);
                                data.DataExport();
                            }
                        }

                    }
                    foreach (var item in data.Doctors)
                    {
                        if (person == item.FullName.ToLower())
                        {
                            if (item.Shifts.Contains(newDuty + 1) || item.Shifts.Contains(newDuty - 1))
                            {
                                Console.WriteLine("Unable to add. Shifts cannot happen day by day.");
                            }
                            else if (isOnDutyThatDay(item.Specialization, newDuty))
                            {
                                Console.WriteLine("There is already doctor with this specialization on duty that day.");
                            }
                            else
                            {
                                item.AddShift(newDuty);
                                data.DataExport();
                            }
                        }
                    }
                    holder();

                }
                else if (selection == 2)
                {
                    Console.Clear();

                    Console.WriteLine("Current schedule:\n");
                    currentSchedule();
                    Console.WriteLine("Please enter a date of a duty you'd like to remove.");
                    int dutyToBeRemoved = int.Parse(Console.ReadLine());
                    foreach (var item in data.Nurses)
                    {
                        if (person == item.FullName.ToLower())
                        {
                            item.RemoveShift(dutyToBeRemoved);
                            holder();
                            data.DataExport();
                        }
                    }
                    foreach (var item in data.Doctors)
                    {
                        if (person == item.FullName.ToLower() && item.Shifts.Count != 0)
                        {
                            item.RemoveShift(dutyToBeRemoved);
                            holder();
                            data.DataExport();
                        }
                    }
                }
                else if (selection == 0)
                {
                    Console.Clear();
                    new Menu();
                }
            }
        }

        private void currentSchedule()
        {
            foreach (var item in data.Nurses)
            {
                if (person == item.FullName.ToLower())
                {
                    item.ShowShifts();
                }
            }
            foreach (var item in data.Doctors)
            {
                if (person == item.FullName.ToLower())
                {
                    item.ShowShifts();
                }
            }
        }

        private void holder()
        {
            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
            Console.Clear();
        }

        private bool isOnDutyThatDay (string specialization, int dutyDay)
        {
            int check = data.Doctors.Count;
            foreach (var item in data.Doctors)
            {
                if (item.Shifts.Contains(dutyDay) && item.Specialization == specialization)
                {
                    check--;
                }
            }
            if (check != data.Doctors.Count)
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