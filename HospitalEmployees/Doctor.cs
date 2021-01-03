using System;
using System.Collections.Generic;
using System.Threading;

namespace HospitalEmployees
{
    public class Doctor: Employee
    {
        public int PWZnumber { get; set; }
        public string Specialization { get; set; }
        public List<int> Shifts { get; set; }

        public Doctor(string name, string surname, string PESEL, string login, string password, string shifts,
            int pwznumber, string specialization)
        {
            this.Role = "doctor";
            this.Name = name;
            this.Surname = surname;
            this.PESEL = PESEL;
            this.login = login;
            this.password = password;
            this.PWZnumber = pwznumber;
            this.Specialization = specialization;
            Shifts = new List<int>();

            string[] split = shifts.Split(',');
            foreach (var item in split)
            {
                Shifts.Add(int.Parse(item));
            }
        }

        public override string GetRole()
        {
            return "doctor";
        }

        public void AddShift(int day)
        {
            if (!Shifts.Contains(day) && Shifts.Count < 10 && day < 30 && day > 0)
            {
                Shifts.Add(day);
                Shifts.Sort();
            }
            else
            {
                Console.WriteLine("Failed to add a shift.");
            }
        }

        public void RemoveShift(int index)
        {
            if (Shifts.Count > 1)
            {
                if (Shifts.Contains(index))
                {
                    Shifts.Remove(index);
                    Shifts.Sort();
                }
                else
                {
                    Console.WriteLine("There is no such shift.");
                }
            }
            else
            {
                Console.WriteLine("There have to be at leat one shift.");
            }
            
        }

        public void ShowShifts()
        {
            Console.WriteLine("There are scheduled shifts at following days of the month:");
            foreach (var item in Shifts)
            {
                Console.Write($"{item}, ");
            }
        }

        public override string Export()
        {
            string shifts_toexport = "";

            for (int i = 0; i < Shifts.Count; i++)
            {
                if (i == Shifts.Count - 1)
                {
                    shifts_toexport += $"{Shifts[i]}";
                }
                else
                {
                    shifts_toexport += $"{Shifts[i]},";
                }
            }


            return $"{Role};{Name};{Surname};{PESEL};{login};{password};{shifts_toexport};{PWZnumber};{Specialization}";
        }

        public bool Login(string login, string password)
        {
            if (base.login == login && base.password == password)
            {
                Console.WriteLine("You have logged in successfully.");
                Thread.Sleep(1000);
                return true;
            }
            else return false;
        }
    }
}
